using System.Text.RegularExpressions;
using TaskInforce.BLL.Constants;
using TaskInforce.BLL.DTO;
using TaskInforce.BLL.Interfaces;
using TaskInforce.BLL.Mapper;
using TaskInforce.DAL.Interfaces;
using TaskInforce.DAL.Models;

namespace TaskInforce.BLL.Services
{
    public class URLService : IURLService
    {
        private readonly IRepository<Url> _urlRepository;
        private readonly IRepository<User> _userRepository;

        public URLService(IRepository<Url> urlRepository, IRepository<User> userRepository)
        {
            _urlRepository = urlRepository;
            _userRepository = userRepository;
        }
        //dead code
        public async Task<URLDTO> GetByIdDtoAsync(int id)
        {
            var shortUrlDto = AutoMapper<Url, URLDTO>.Map(await _urlRepository.GetByIdAsync(id));
            shortUrlDto.ShortUrl = ShortUrlHelper.Encode(id);

            return shortUrlDto;
        }

        public async Task<URLDTO> GetByShortUrlAsync(string shortUrl)
        {
            var shortUrlDto = AutoMapper<Url, URLDTO>.Map(await _urlRepository.GetByIdAsync(ShortUrlHelper.Decode(shortUrl)));
            shortUrlDto.ShortUrl = shortUrl;

            return shortUrlDto;
        }

        public async Task<URLDTO> GetByOriginalUrlAsync(string originalUrl)
        {
            var urls = await _urlRepository.GetAllAsync();

            foreach (var shortUrl in urls)
            {
                if (shortUrl.OriginalUrl == originalUrl)
                {
                    var shortUrlDto = AutoMapper<Url, URLDTO>.Map(shortUrl);
                    shortUrlDto.ShortUrl = ShortUrlHelper.Encode(shortUrl.Id);

                    return shortUrlDto;
                }
            }

            return null;
        }

        public async Task<IEnumerable<URLDTO>> GetAllUrlsAsync()
        {
            var URLs = await _urlRepository.GetAllAsync();
            var urlDtos = new List<URLDTO>();

            foreach (var url in URLs)
            {
                var user = await _userRepository.GetByIdAsync(url.UserId);

                urlDtos.Add(new URLDTO()
                {
                    Id = url.Id,
                    OriginalUrl = url.OriginalUrl,
                    ShortUrl = ShortUrlHelper.Encode(url.Id),
                    CreatedByUserName = user.UserName,
                    CreatedAt = url.CreatedAt
                });
            }

            return urlDtos;
        }

        public async Task AddAsync(CreateShortUrlDTO entity)
        {
            var pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var validate = regex.IsMatch(entity.OriginalUrl);

            var url = await _urlRepository.FindFirstAsync(expression: x => x.OriginalUrl == entity.OriginalUrl);

            if (url is not null) 
            { 
                throw new ArgumentException(ErrorMessages.URL_Already_Exist);
            }

            if (!validate)
            {
                throw new ArgumentException(ErrorMessages.URL_Is_Not_Valid);
            }

            await _urlRepository.AddAsync(AutoMapper<CreateShortUrlDTO, Url>.Map(entity));
        }

        public async Task DeleteAsync(int id)
        {
            Url url = await _urlRepository.GetByIdAsync(id);
            await _urlRepository.RemoveAsync(url);
        }

        public async Task<Url> GetByIdAsync(int id)
        {
            return await _urlRepository.GetByIdAsync(id);
        }
    }
}
