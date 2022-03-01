using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OZ.Repositories
{
    public interface IRepositoryBase<T>
    {
        //IQueryable<T> FindAll<T>() where T : class;
        //IQueryable<T> FindByCondition<T>(Expression<Func<T, bool>> expression) where T : class;
        //T Create<T>(T entity) where T : class;
        //void Update<T>(T entity) where T : class;
        //void Delete<T>(T entity) where T : class;

        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
