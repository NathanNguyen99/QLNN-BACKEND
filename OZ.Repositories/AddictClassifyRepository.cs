using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class AddictClassifyRepository : RepositoryBase<AddictClassify>, IAddictClassifyRepository
    {
        public AddictClassifyRepository(ApplicationContext context) : base(context)
        { }

        public AddictClassifyDto SaveCreate(AddictClassify domain)
        {
            try
            {
                var us = Create(domain);
                var obj = new AddictClassifyDto()
                {
                    OID = us.OID,
                    AddictID = us.AddictID,
                    //AddictCode = a.AddictCode,
                    //AddictName = a.LastName + ' ' + a.FirstName,
                    ClassifyID = us.ClassifyID,                    
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

        public new bool Update(AddictClassify domain)
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
                AddictClassify user = RepositoryContext.AddictClassifys.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
                //throw ex;
                Commons.NLogAction.instance.logger.Error(ex);
                return false;
            }
        }
        public IEnumerable<AddictClassifyDto> GetAll()
        {
            try
            {
                var lstResult = (from c in FindAll()
                                 join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                                 join p in RepositoryContext.Classifys on c.ClassifyID equals p.OID into ps
                                 from p1 in ps.DefaultIfEmpty()                                                               
                                 select new AddictClassifyDto()
                                 {
                                     OID = c.OID,
                                     AddictID = c.AddictID,
                                     AddictCode = a.AddictCode,
                                     AddictName = a.LastName + ' ' + a.FirstName,
                                     ClassifyID = c.ClassifyID,
                                     ClassifyName = p1.ClassifyName,                                    
                                     Remarks = c.Remarks
                                 });
                return lstResult;//.OrderBy(x => x.ClassifyID);
            }
            catch (Exception ex)
            {
                //ErrorManager.ErrorHandler.HandleError(ex);
                //throw ex;
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }
        public PagedList<AddictClassifyDto> GetAddictClassifys(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(searchString))
                searchString = "";

            var lstResult = (from c in FindAll()
                             join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                             join p in RepositoryContext.Classifys on c.ClassifyID equals p.OID into ps
                             from p1 in ps.DefaultIfEmpty()                             
                             where c.Remarks.Contains(searchString) || a.AddictCode.Contains(searchString) || a.FirstName.Contains(searchString)
                             || a.LastName.Contains(searchString) || p1.ClassifyName.Contains(searchString)
                             select new AddictClassifyDto()
                             {
                                 OID = c.OID,
                                 AddictID = c.AddictID,
                                 AddictCode = a.AddictCode,
                                 AddictName = a.LastName + ' ' + a.FirstName,
                                 ClassifyID = c.ClassifyID,
                                 ClassifyName = p1.ClassifyName,                                                            
                                 Remarks = c.Remarks
                             });


            if (!String.IsNullOrEmpty(sortName) && !string.IsNullOrEmpty(sortDirection))
            {
                if (sortDirection.Contains("asc"))
                {
                    switch (sortName)
                    {
                        
                        case nameof(AddictClassify.Remarks):
                            lstResult = lstResult.OrderBy(r => r.Remarks);
                            break;                        
                        case "ClassifyName":
                            lstResult = lstResult.OrderBy(r => r.ClassifyName);
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
                        case nameof(AddictClassify.Remarks):
                            lstResult = lstResult.OrderByDescending(r => r.Remarks);
                            break;                        
                        case "ClassifyName":
                            lstResult = lstResult.OrderByDescending(r => r.ClassifyName);
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
            return PagedList<AddictClassifyDto>.ToPagedList(lstResult, pageNumber, pageSize);
        }
        public AddictClassifyDto GetByID(Guid id)
        {
            var objResult = (from c in FindAll()
                             join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                             join p in RepositoryContext.Classifys on c.ClassifyID equals p.OID into ps
                             from p1 in ps.DefaultIfEmpty()
                             
                             where c.OID == id
                             select new AddictClassifyDto()
                             {
                                 OID = c.OID,
                                 AddictID = c.AddictID,
                                 AddictCode = a.AddictCode,
                                 AddictName = a.LastName + ' ' + a.FirstName,
                                 ClassifyID = c.ClassifyID,
                                 ClassifyName = p1.ClassifyName,
                                 
                                 Remarks = c.Remarks
                             }).FirstOrDefault();
            //AddictClassify user = RepositoryContext.AddictClassifys.Where(x => x.OID.Equals(id)).FirstOrDefault();
            if (objResult != null)
            {
                return objResult;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<AddictClassifyDto> GetByAddictID(Guid addictID)
        {
            try
            {
                var lstResult = (from c in FindAll()
                                 join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                                 join p in RepositoryContext.Classifys on c.ClassifyID equals p.OID into ps
                                 from p1 in ps.DefaultIfEmpty()
                                 
                                 where c.AddictID == addictID
                                 select new AddictClassifyDto()
                                 {
                                     OID = c.OID,
                                     AddictID = c.AddictID,
                                     AddictCode = a.AddictCode,
                                     AddictName = a.LastName + ' ' + a.FirstName,
                                     ClassifyID = c.ClassifyID,
                                     ClassifyName = p1.ClassifyName,
                                     
                                     Remarks = c.Remarks
                                 });
                return lstResult;
                //return RepositoryContext.AddictClassifys.Where(r => r.AddictID == addictID);//.OrderBy(x => x.ClassifyID);
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
