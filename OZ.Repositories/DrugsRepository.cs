using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class DrugsRepository : RepositoryBase<Drugs>, IDrugsRepository
    {
        public DrugsRepository(ApplicationContext context) : base(context)
        { }

        public Drugs Save(Drugs domain)
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

        public new bool Update(Drugs domain)
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
                Drugs user = RepositoryContext.Drugss.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
        public IEnumerable<Drugs> GetAll()
        {
            try
            {
                //Commons.NLogAction.instance.logger.Error("vô dây rồi hehehe");
                return RepositoryContext.Drugss.OrderBy(x => x.OID);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public Drugs GetByID(int id)
        {
            Drugs user = RepositoryContext.Drugss.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
