
using System.Linq.Expressions;
using Application.Interfaces;
using Infrastructures.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructures.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }
        public async Task<bool> Add(TEntity entity,CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(TEntity entity, CancellationToken cancellationToken)
        {
             _dbSet.Remove(entity);
             return await _appDbContext.SaveChangesAsync()>0;
        }

        public async Task<bool> Update(TEntity entity, CancellationToken cancellationToken)
        {
                _dbSet.Update(entity);
               return await _appDbContext.SaveChangesAsync()>0;
        }

        public async Task<List<TEntity>> GetBy(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(expression).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(Id);
        }

    }
}
