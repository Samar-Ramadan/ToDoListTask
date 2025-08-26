using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<List<TEntity>> GetBy(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        public Task<TEntity> GetById(int Id, CancellationToken cancellationToken);
        public Task<bool> Add(TEntity entity, CancellationToken cancellationToken);
        public Task<bool> Delete(TEntity entity, CancellationToken cancellationToken);
        public Task<bool> Update(TEntity entity, CancellationToken cancellationToken);
    }
}
