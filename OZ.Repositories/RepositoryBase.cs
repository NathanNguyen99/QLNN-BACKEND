using OZ.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OZ.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext RepositoryContext { get; set; }
        public RepositoryBase(ApplicationContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public IQueryable<T>FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public T Create(T entity)
        {
            var rentity = this.RepositoryContext.Set<T>().Add(entity);
            this.RepositoryContext.SaveChanges();
            return rentity.Entity;
        }
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            //this.RepositoryContext.Entry<T>(entity).State = EntityState.Modified;
            this.RepositoryContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            this.RepositoryContext.SaveChanges();

        }
    }

    public abstract class RepositoryBase
    {
        protected ApplicationContext RepositoryContext { get; set; }
        public RepositoryBase(ApplicationContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;

        }
    }
}
