using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.IGenericRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();
        public IQueryable<TEntity> GetBy(Expression<Func<TEntity,bool>> expression);
        public TEntity GetById(int Id);
        public TEntity Add(TEntity entity);
        public void Delete(TEntity entity);
        public TEntity Update(TEntity entity);
    }
}
