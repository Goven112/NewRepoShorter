using TaskInforce.BLL.DTO;
using TaskInforce.DAL.Models;

namespace TaskInforce.BLL.Interfaces
{
    public interface IURLService
    {
        Task AddAsync(CreateShortUrlDTO entity);

        Task DeleteAsync(int id);

        Task<IEnumerable<URLDTO>> GetAllUrlsAsync();

        Task<URLDTO> GetByIdDtoAsync(int id);

        Task<URLDTO> GetByOriginalUrlAsync(string originalUrl);

        Task<URLDTO> GetByShortUrlAsync(string shortUrl);

        Task<Url> GetByIdAsync(int id);
    }
}
