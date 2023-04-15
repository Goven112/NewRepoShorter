using TaskInforce.DAL.Models;

namespace TaskInforce.DAL.Repositories
{
    public class UserRefreshTokenRepository : Repository<UserRefreshToken>
    {
        public UserRefreshTokenRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
