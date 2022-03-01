using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class ProvinceRepository : RepositoryBase<Province>, IProvinceRepository
    {
        public ProvinceRepository(ApplicationContext context) : base(context)
        { }

        public Province Save(Province domain)
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

        public new bool Update(Province domain)
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
        public bool Delete(Guid id)
        {
            try
            {
                Province user = RepositoryContext.Provinces.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
        public IEnumerable<Province> GetAll()
        {
            try
            {
                return RepositoryContext.Provinces.OrderBy(x => x.Seq);
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                throw ex;
            }
        }

        public Province GetByID(int id)
        {
            Province user = RepositoryContext.Provinces.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
