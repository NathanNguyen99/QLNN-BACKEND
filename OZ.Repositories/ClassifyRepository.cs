using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class ClassifyRepository : RepositoryBase<Classify>, IClassifyRepository
    {
        public ClassifyRepository(ApplicationContext context) : base(context)
        { }

        public Classify Save(Classify domain)
        {
            try
            {
                var us = Create(domain);
                return us;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public new bool Update(Classify domain)
        {
            try
            {
                //domain.Updated = DateTime.Now;
                base.Update(domain);
                return true;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Classify user = RepositoryContext.Classifys.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<Classify> GetAll()
        {
            try
            {
                //Commons.NLogAction.instance.logger.Error("vô dây rồi hehehe");
                return RepositoryContext.Classifys.OrderBy(x => x.OID);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public Classify GetByID(int id)
        {
            Classify user = RepositoryContext.Classifys.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
