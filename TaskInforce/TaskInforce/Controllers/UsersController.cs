using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskInforce.BLL.Constants;
using TaskInforce.BLL.DTO;
using TaskInforce.BLL.Interfaces;
using TaskInforce.DAL.Models;

namespace TaskInforce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
 
        [HttpGet("getAll")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("getById/{id}")]
        public async Task<User> GetById(int id)
        {
            return await _userService.GetByIdAsync(id);
        }

        // POST: Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO entity)
        {
            try
            {
                await _userService.AddAsync(entity);
                return Ok(entity);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("deleteById/{id}")]
        public async Task Delete(int id)
        {
            await _userService.RemoveAsync(id);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UserDTO entity)
        {
            await _userService.UpdateAsync(entity);
            return Ok(entity);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthDTO authDto)
        {
            try
            {
                var tokens = await _userService.LoginAsync(authDto);
                var user = await _userService.IsValidUserAsync(authDto.Email, authDto.Password);
                return Ok(new { tokens, user });
            }
            catch (ArgumentException)
            {
                // Magic strings
                return Unauthorized(ErrorMessages.IncorrectEmailOrPassword);
            }
            catch (OperationCanceledException)
            {
                return Unauthorized(ErrorMessages.Invalid_Attempt);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh")]
        public async Task RefreshToken([FromBody] TokenDTO tokensDto)
        {
            try
            {
                await _userService.RefreshTokenAsync(tokensDto);
            }
            catch (OperationCanceledException)
            {
                Unauthorized(ErrorMessages.Invalid_Attempt);
            }
        }

    }
}
