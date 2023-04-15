using TaskInforce.DAL.Models;

namespace TaskInforce.DAL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
