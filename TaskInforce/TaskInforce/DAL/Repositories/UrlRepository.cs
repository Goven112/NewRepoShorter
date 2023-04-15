using TaskInforce.DAL.Models;

namespace TaskInforce.DAL.Repositories
{
    public class URLRepository : Repository<Url>
    {
        public URLRepository(ApplicationContext context) : base(context)
        {
             
        }
    }
}
