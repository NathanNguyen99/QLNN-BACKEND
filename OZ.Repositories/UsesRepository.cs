using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class UsesRepository : RepositoryBase<Uses>, IUsesRepository
    {
        public UsesRepository(ApplicationContext context) : base(context)
        { }

        public Uses Save(Uses domain)
        {
            try
            {
                var us = Create(domain);
                return us;
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                throw ex;
            }
        }
        //public new Employee Create(Employee domain)
        //{
        //    Employee user = RepositoryContext.EmployeesDB.Where(x => x.Oid.Equals(id)).FirstOrDefault();
        //}
        public new bool Update(Uses domain)
        {
            try
            {
                //domain.Updated = DateTime.Now;
                base.Update(domain);
                return true;
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                throw ex;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Uses user = RepositoryContext.Usess.Where(x => x.OID.Equals(id)).FirstOrDefault();
                if (user != null)
                {
                    Delete(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                throw ex;
            }
        }
        public IEnumerable<Uses> GetAll()
        {
            try
            {
                return RepositoryContext.Usess;//.OrderBy(x => x.MethodName);
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                throw ex;
            }
        }

        public Uses GetByID(int id)
        {
            Uses user = RepositoryContext.Usess.Where(x => x.OID.Equals(id)).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
