using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class AddictDrugsRepository : RepositoryBase<AddictDrugs>, IAddictDrugsRepository
    {
        public AddictDrugsRepository(ApplicationContext context) : base(context)
        { }

        public AddictDrugDto SaveCreate(AddictDrugs domain)
        {
            try
            {
                var us = Create(domain);
                var obj = new AddictDrugDto()
                {
                    OID = us.OID,
                    AddictID = us.AddictID,
                    //AddictCode = a.AddictCode,
                    //AddictName = a.LastName + ' ' + a.FirstName,
                    DrugsID = us.DrugsID,
                    //PlaceName = p2.PlaceName,
                    UseID = us.UseID,
                    //PlaceTypeName = p1.PlaceTypeName,
                    inUse = us.inUse,
                    Remarks = us.Remarks
                };

                return obj;
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError();
                //throw ex;
                Commons.NLogAction.instance.logger.Error(ex);
                return null;                
            }
        }

        public new bool Update(AddictDrugs domain)
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
                //throw ex;
                Commons.NLogAction.instance.logger.Error(ex);
                return false;                
            }
        }
        public bool Delete(Guid id)
        {
            try
            {
                AddictDrugs user = RepositoryContext.AddictDrugss.Where(x => x.OID.Equals(id)).FirstOrDefault();
                if (user != null)
                {
                    base.Delete(user);
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
                //throw ex;
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<AddictDrugDto> GetAll()
        {
            try
            {
                var lstResult = (from c in FindAll()
                                 join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                                 join p in RepositoryContext.Drugss on c.DrugsID equals p.OID into ps
                                 from p1 in ps.DefaultIfEmpty()
                                 join l in RepositoryContext.Usess on c.UseID equals l.OID into ps1
                                 from p2 in ps1.DefaultIfEmpty()                                 
                                 select new AddictDrugDto()
                                 {
                                     OID = c.OID,
                                     AddictID = c.AddictID,
                                     AddictCode = a.AddictCode,
                                     AddictName = a.LastName + ' ' + a.FirstName,
                                     DrugsID = c.DrugsID,
                                     DrugsName = p1.DrugsName,
                                     UseID = c.UseID,
                                     UseName = p2.MethodName,
                                     inUse = c.inUse,
                                     Remarks = c.Remarks
                                 });
                return lstResult;//.OrderBy(x => x.DrugsID);
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                //throw ex;
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }
        public PagedList<AddictDrugDto> GetAddictDrugs(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(searchString))
                searchString = "";

            var lstResult = (from c in FindAll()
                             join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                             join p in RepositoryContext.Drugss on c.DrugsID equals p.OID into ps
                             from p1 in ps.DefaultIfEmpty()
                             join l in RepositoryContext.Usess on c.UseID equals l.OID into ps1
                             from p2 in ps1.DefaultIfEmpty()
                             where c.Remarks.Contains(searchString) || a.AddictCode.Contains(searchString) || a.FirstName.Contains(searchString)
                             || a.LastName.Contains(searchString) || p1.DrugsName.Contains(searchString) || p2.MethodName.Contains(searchString)
                             select new AddictDrugDto()
                             {
                                 OID = c.OID,
                                 AddictID = c.AddictID,
                                 AddictCode = a.AddictCode,
                                 AddictName = a.LastName + ' ' + a.FirstName,
                                 DrugsID = c.DrugsID,
                                 DrugsName = p1.DrugsName,
                                 UseID = c.UseID,
                                 UseName = p2.MethodName,
                                 inUse = c.inUse,                                 
                                 Remarks = c.Remarks
                             });


            if (!String.IsNullOrEmpty(sortName) && !string.IsNullOrEmpty(sortDirection))
            {
                if (sortDirection.Contains("asc"))
                {
                    switch (sortName)
                    {
                        
                        case nameof(AddictDrugs.Remarks):
                            lstResult = lstResult.OrderBy(r => r.Remarks);
                            break;
                        case "UseName":
                            lstResult = lstResult.OrderBy(r => r.UseName);
                            break;
                        case "DrugsName":
                            lstResult = lstResult.OrderBy(r => r.DrugsName);
                            break;
                        case "AddictCode":
                            lstResult = lstResult.OrderBy(r => r.AddictCode);
                            break;
                        case "AddictName":
                            lstResult = lstResult.OrderBy(r => r.AddictName);
                            break;
                    }
                }
                else
                {
                    switch (sortName)
                    {                        
                        case nameof(AddictDrugs.Remarks):
                            lstResult = lstResult.OrderByDescending(r => r.Remarks);
                            break;
                        case "UseName":
                            lstResult = lstResult.OrderByDescending(r => r.UseName);
                            break;
                        case "DrugsName":
                            lstResult = lstResult.OrderByDescending(r => r.DrugsName);
                            break;
                        case "AddictCode":
                            lstResult = lstResult.OrderByDescending(r => r.AddictCode);
                            break;
                        case "AddictName":
                            lstResult = lstResult.OrderByDescending(r => r.AddictName);
                            break;
                    }
                }
            }
            return PagedList<AddictDrugDto>.ToPagedList(lstResult, pageNumber, pageSize);
        }
        public AddictDrugDto GetByID(Guid id)
        {
            var objResult = (from c in FindAll()
                             join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                             join p in RepositoryContext.Drugss on c.DrugsID equals p.OID into ps
                             from p1 in ps.DefaultIfEmpty()
                             join l in RepositoryContext.Usess on c.UseID equals l.OID into ps1
                             from p2 in ps1.DefaultIfEmpty()
                             where c.OID == id
                             select new AddictDrugDto()
                             {
                                 OID = c.OID,
                                 AddictID = c.AddictID,
                                 AddictCode = a.AddictCode,
                                 AddictName = a.LastName + ' ' + a.FirstName,
                                 DrugsID = c.DrugsID,
                                 DrugsName = p1.DrugsName,
                                 UseID = c.UseID,
                                 UseName = p2.MethodName,
                                 inUse = c.inUse,
                                 Remarks = c.Remarks
                             }).FirstOrDefault();
            //AddictDrugs user = RepositoryContext.AddictDrugss.Where(x => x.OID.Equals(id)).FirstOrDefault();
            if (objResult != null)
            {
                return objResult;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<AddictDrugDto> GetByAddictID(Guid addictID)
        {
            try
            {
                var lstResult = (from c in FindAll()
                                 join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                                 join p in RepositoryContext.Drugss on c.DrugsID equals p.OID into ps
                                 from p1 in ps.DefaultIfEmpty()
                                 join l in RepositoryContext.Usess on c.UseID equals l.OID into ps1
                                 from p2 in ps1.DefaultIfEmpty()
                                 where c.AddictID == addictID
                                 select new AddictDrugDto()
                                 {
                                     OID = c.OID,
                                     AddictID = c.AddictID,
                                     AddictCode = a.AddictCode,
                                     AddictName = a.LastName + ' ' + a.FirstName,
                                     DrugsID = c.DrugsID,
                                     DrugsName = p1.DrugsName,
                                     UseID = c.UseID,
                                     UseName = p2.MethodName,
                                     inUse = c.inUse,
                                     Remarks = c.Remarks
                                 });
                return lstResult;
                //return RepositoryContext.AddictDrugss.Where(r => r.AddictID == addictID);//.OrderBy(x => x.DrugsID);
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                //throw ex;
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }
    }
}
