
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
        public async Task<bool> AddAsync(TEntity entity,CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
             _dbSet.Remove(entity);
             return await _appDbContext.SaveChangesAsync()>0;
        }

        public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
                _dbSet.Update(entity);
               return await _appDbContext.SaveChangesAsync()>0;
        }

        public async Task<List<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> expression,
                                                    Expression<Func<TEntity, object>> includeExpression,
                                                    CancellationToken cancellationToken)
        {
            return await _dbSet.Where(expression).Include(includeExpression).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(Id);
        }

    }
}
