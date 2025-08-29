using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<List<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> includeExpression, CancellationToken cancellationToken);
        public Task<TEntity> GetByIdAsync(int Id, CancellationToken cancellationToken);
        public Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken);
        public Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        public Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
