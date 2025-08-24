using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using Core.IGenericRepository;
using Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repository
{
    //public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    //{
    //    protected readonly AppDbContext _appDbContext;
    //    protected readonly DbSet<TEntity> _dbSet;
    //    public Repository(AppDbContext appDbContext)
    //    {
    //        _appDbContext = appDbContext;
    //        _dbSet = appDbContext.Set<TEntity>();
    //    }
    //    public TEntity Add(TEntity entity)
    //    {
    //        if (_dbSet != null)
    //        {
    //            _dbSet.Add(entity);
    //            _appDbContext.SaveChanges();
    //            return entity;
    //        }
    //        else
    //        {
    //            throw new ArgumentNullException(nameof(entity));
    //        }
    //    }

    //    void IRepository<TEntity>.Delete(TEntity entity)
    //    {
    //        if (_dbSet != null)
    //        {
    //            _dbSet.Remove(entity);
    //            _appDbContext.SaveChanges();
    //        }
    //        else
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }

    //    void IRepository<TEntity>.Update(TEntity entity)
    //    {
    //        if (_dbSet != null)
    //        {
    //            _dbSet.Update(entity);
    //            _appDbContext.SaveChanges();
    //        }
    //        else
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }

    //    IQueryable<TEntity> IRepository<TEntity>.GetBy(Expression<Func<TEntity, bool>> expression)
    //    {
    //        return _dbSet.Where(expression);
    //    }

    //    TEntity IRepository<TEntity>.GetById(int Id)
    //    {
    //        return _dbSet.Find(Id);
    //    }

    //    public IEnumerable<TEntity> GetAll()
    //    {
    //        return _dbSet.ToList();
    //    }
    //}
}
