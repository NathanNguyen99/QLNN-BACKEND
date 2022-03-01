using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class EducationLevelRepository : RepositoryBase<EducationLevel>, IEducationLevelRepository
    {
        public EducationLevelRepository(ApplicationContext context) : base(context)
        { }

        public EducationLevel Save(EducationLevel domain)
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
        //public new Employee Create(Employee domain)
        //{
        //    Employee user = RepositoryContext.EmployeesDB.Where(x => x.Oid.Equals(id)).FirstOrDefault();
        //}
        public new bool Update(EducationLevel domain)
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
        public bool Delete(Guid id)
        {
            try
            {
                EducationLevel user = RepositoryContext.EducationLevels.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
        public IEnumerable<EducationLevel> GetAll()
        {
            try
            {
                return RepositoryContext.EducationLevels.OrderBy(x => x.Seq);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public EducationLevel GetByID(Guid id)
        {
            EducationLevel user = RepositoryContext.EducationLevels.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
