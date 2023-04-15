using Microsoft.AspNetCore.Mvc;
using TaskInforce.BLL.DTO;
using TaskInforce.BLL.Interfaces; 
using TaskInforce.DAL.Models;

namespace TaskInforce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IURLService _urlService;
        //Controller must be UrlsController
        public UrlController(IURLService urlService)
        {
            _urlService = urlService;
        }
        //cant be verb in attttribute
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateShortUrlDTO createUrl)
        {
            try
            {
                await _urlService.AddAsync(createUrl);
                return Ok(createUrl);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetByOriginalUrl/{url}")]
        public async Task<URLDTO> GetByOriginalUrl(string url)
        {
            return await _urlService.GetByOriginalUrlAsync(url);
        }

        [HttpGet("GetByShortUrl/{url}")]
        public async Task<URLDTO> GetByShortUrl(string url)
        {
            return await _urlService.GetByShortUrlAsync(url);
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<URLDTO>> GetAllUrls()
        {
            return await _urlService.GetAllUrlsAsync();
        }

        [HttpDelete("Delete/{id}")]
        public async Task DeleteUrl(int id)
        {
            await _urlService.DeleteAsync(id);
        }
        
        [HttpGet("getById/{id}")]
        public async Task<Url> GetById(int id)
        {
            return await _urlService.GetByIdAsync(id);
        }
    }
}