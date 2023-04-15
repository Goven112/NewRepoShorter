using TaskInforce.BLL.DTO;
using TaskInforce.DAL.Models;

namespace TaskInforce.BLL.Interfaces
{
    public interface IUserService
    {
        Task AddAsync(CreateUserDTO entity);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task<User> IsValidUserAsync(string email, string password);

        Task<TokenDTO> LoginAsync(AuthDTO authDto);

        Task<TokenDTO> RefreshTokenAsync(TokenDTO tokensDto);

        Task RemoveAsync(int id);

        Task UpdateAsync(UserDTO entity);
    }
}
