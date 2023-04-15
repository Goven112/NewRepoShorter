using System.Linq.Expressions;

namespace TaskInforce.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> expression);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task RemoveAsync(TEntity entity);

        Task SaveChangesAsync();

        Task UpdateAsync(TEntity entity);
    }
}
