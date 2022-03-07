using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class AddictRelationsRepository : RepositoryBase<AddictRelations>, IAddictRelationsRepository
    {
        public AddictRelationsRepository(ApplicationContext context) : base(context)
        { }

        public AddictRelationsDto SaveCreate(AddictRelations domain)
        {
            try
            {
                var us = Create(domain);
                var obj = new AddictRelationsDto()
                {
                    OID = us.OID,
                    AddictID = us.AddictID,
                    RelationWithID = us.RelationWithID,
                    Date = us.Date,
                    DateOfBirth = us.DateOfBirth,

                    OtherName = us.OtherName,
                    ManagePlaceID = us.ManagePlaceID,
                    BlackList = us.BlackList,
                    CurrentAddress = us.CurrentAddress,

                    RelationsID = us.RelationsID,
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

        public new bool Update(AddictRelations domain)
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
                AddictRelations user = RepositoryContext.AddictRelations.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
        public IEnumerable<AddictRelationsDto> GetAll()
        {
            try
            {
                var lstResult = (from c in FindAll()
                                 join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                                 join b in RepositoryContext.Addicts on c.RelationWithID equals b.OID

                                 join e in RepositoryContext.ManagePlaces on c.ManagePlaceID equals e.OID into ps2
                                 from p2 in ps2.DefaultIfEmpty()

                                 join p in RepositoryContext.Relations on c.RelationsID equals p.OID into ps
                                 from p1 in ps.DefaultIfEmpty()
                                 select new AddictRelationsDto()
                                 {
                                     OID = c.OID,
                                     AddictID = c.AddictID,
                                     AddictCode = a.AddictCode,
                                     AddictName = a.LastName + ' ' + a.FirstName,

                                     OtherName = c.OtherName,
                                     ManagePlaceID = c.ManagePlaceID,
                                     ManagePlaceName  = p2.PlaceName,
                                     BlackList = c.BlackList,
                                     CurrentAddress = c.CurrentAddress,
                                     DateOfBirth = c.DateOfBirth,

                                     RelationWithID = c.RelationWithID,                                    
                                     RelationWithName = b.LastName + ' ' + b.FirstName,

                                     Date = c.Date,

                                     RelationsID = c.RelationsID,
                                     RelationsName = p1.RelationName,
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
        public PagedList<AddictRelationsDto> GetAddictRelations(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(searchString))
                searchString = "";

            var lstResult = (from c in FindAll()
                             join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                             join b in RepositoryContext.Addicts on c.RelationWithID equals b.OID
                             join e in RepositoryContext.ManagePlaces on c.ManagePlaceID equals e.OID into ps2
                             from p2 in ps2.DefaultIfEmpty()
                             join p in RepositoryContext.Relations on c.RelationsID equals p.OID into ps
                             from p1 in ps.DefaultIfEmpty()
                             where c.Remarks.Contains(searchString) || a.AddictCode.Contains(searchString) || a.FirstName.Contains(searchString)
                             || a.LastName.Contains(searchString) || p1.RelationName.Contains(searchString) || b.FirstName.Contains(searchString)
                             || b.LastName.Contains(searchString) 
                             select new AddictRelationsDto()
                             {
                                 OID = c.OID,
                                 AddictID = c.AddictID,
                                 AddictCode = a.AddictCode,
                                 AddictName = a.LastName + ' ' + a.FirstName,

                                 OtherName = c.OtherName,
                                 ManagePlaceID = c.ManagePlaceID,
                                 ManagePlaceName  = p2.PlaceName,
                                 BlackList = c.BlackList,
                                 CurrentAddress = c.CurrentAddress,
                                 DateOfBirth = c.DateOfBirth,


                                 RelationWithID = c.RelationWithID,
                                 RelationWithName = b.LastName + ' ' + b.FirstName,
                                 Date = c.Date,

                                 RelationsID = c.RelationsID,
                                 RelationsName = p1.RelationName,
                                                                
                                 Remarks = c.Remarks
                             });


            if (!String.IsNullOrEmpty(sortName) && !string.IsNullOrEmpty(sortDirection))
            {
                if (sortDirection.Contains("asc"))
                {
                    switch (sortName)
                    {
                        
                        case nameof(AddictRelations.Remarks):
                            lstResult = lstResult.OrderBy(r => r.Remarks);
                            break;
                        case "RelationsName":
                            lstResult = lstResult.OrderBy(r => r.RelationsName);
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
                        
                        case "RelationsName":
                            lstResult = lstResult.OrderByDescending(r => r.RelationsName);
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
            return PagedList<AddictRelationsDto>.ToPagedList(lstResult, pageNumber, pageSize);
        }

        public IEnumerable<AddictRelationsDto2> GetAddictRelations2(IAddictRepository addictRepository)
        {

            //if (string.IsNullOrEmpty(searchString))
            //    searchString = "";
            //
            var lstResult = (from a in addictRepository.GetAll()
                                 //join p in RepositoryContext.AddictRelations on a.OID equals p.AddictID
                             select new AddictRelationsDto2()
                             {
                                 AddictID = a.OID,
                                 AddictCode = a.AddictCode,
                                 AddictName = a.FullName,
                                 DOB = a.DateOfBirth
                             });
         
            var query = lstResult.GroupBy(x => x)
              .Where(g => g.Count() >= 0)
              .Select(y => y.Key)
              .ToList();

            //if (!String.IsNullOrEmpty(sortName) && !string.IsNullOrEmpty(sortDirection))
            //{
            //    if (sortDirection.Contains("asc"))
            //    {
            //        switch (sortName)
            //        {
            //            case nameof(AddictRelationsDto2.DOB):
            //                lstResult = lstResult.OrderBy(r => r.DOB);
            //                break;
            //            case "AddictCode":
            //                lstResult = lstResult.OrderBy(r => r.AddictCode);
            //                break;
            //            case "AddictName":
            //                lstResult = lstResult.OrderBy(r => r.AddictName);
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        switch (sortName)
            //        {
            //            case nameof(AddictRelationsDto2.DOB):
            //                lstResult = lstResult.OrderByDescending(r => r.DOB);
            //                break;
            //            case "AddictCode":
            //                lstResult = lstResult.OrderByDescending(r => r.AddictCode);
            //                break;
            //            case "AddictName":
            //                lstResult = lstResult.OrderByDescending(r => r.AddictName);
            //                break;
            //        }
            //    }
            //}

            var lst1 = query.ToList();
            foreach (var item in lst1)
            {
                
                var lstActivitys = (from c in FindAll()
                               
                                 join b in RepositoryContext.Addicts on c.RelationWithID equals b.OID
                                 join e in RepositoryContext.ManagePlaces on c.ManagePlaceID equals e.OID into ps2
                                 from p2 in ps2.DefaultIfEmpty()
                                 join p in RepositoryContext.Relations on c.RelationsID equals p.OID into ps
                                 from p1 in ps.DefaultIfEmpty()
                                    where c.AddictID == item.AddictID
                                    select new AddictRelationsDto()
                                 {
                                     OID = c.OID,
                                     AddictID = c.AddictID,
                                     

                                     OtherName = c.OtherName,
                                     ManagePlaceID = c.ManagePlaceID,
                                     ManagePlaceName  = p2.PlaceName,
                                     BlackList = c.BlackList,
                                     CurrentAddress = c.CurrentAddress,
                                     DateOfBirth = c.DateOfBirth,


                                     RelationWithID = c.RelationWithID,
                                     RelationWithName = b.LastName + ' ' + b.FirstName,
                                     Date = c.Date,

                                     RelationsID = c.RelationsID,
                                     RelationsName = p1.RelationName,

                                     Remarks = c.Remarks
                                 });
                item.ActivityLog = lstActivitys.ToList();


            }
            return lst1;

            //return PagedList<AddictRelationsDto2>.ToPagedList((lst1.AsQueryable()), pageNumber, pageSize);
            //groupedCustomerList.AsQueryable()
        }

        public AddictRelationsDto GetByID(Guid id)
        {
            var objResult = (from c in FindAll()
                             join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                             join b in RepositoryContext.Addicts on c.RelationWithID equals b.OID
                             join e in RepositoryContext.ManagePlaces on c.ManagePlaceID equals e.OID into ps2
                             from p2 in ps2.DefaultIfEmpty()
                             join p in RepositoryContext.Relations on c.RelationsID equals p.OID into ps
                             from p1 in ps.DefaultIfEmpty()
                             
                             where c.OID == id
                             select new AddictRelationsDto()
                             {
                                 OID = c.OID,
                                 AddictID = c.AddictID,
                                 AddictCode = a.AddictCode,
                                 AddictName = a.LastName + ' ' + a.FirstName,
                                 OtherName = c.OtherName,
                                 ManagePlaceID = c.ManagePlaceID,
                                 ManagePlaceName  = p2.PlaceName,
                                 BlackList = c.BlackList,
                                 CurrentAddress = c.CurrentAddress,
                                 DateOfBirth = c.DateOfBirth,

                                 RelationWithID = c.RelationWithID,
                                 RelationWithName = b.LastName + ' ' + b.FirstName,
                                 Date = c.Date,
                                 RelationsID = c.RelationsID,
                                 RelationsName = p1.RelationName,
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

        public IEnumerable<AddictRelationsDto> GetByAddictID(Guid addictID)
        {
            try
            {
                var lstResult = (from c in FindAll()
                                 join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                                 join b in RepositoryContext.Addicts on c.RelationWithID equals b.OID
                                 join e in RepositoryContext.ManagePlaces on c.ManagePlaceID equals e.OID into ps2
                                 from p2 in ps2.DefaultIfEmpty()
                                 join p in RepositoryContext.Relations on c.RelationsID equals p.OID into ps
                                 from p1 in ps.DefaultIfEmpty()
                                 
                                 where c.AddictID == addictID
                                 select new AddictRelationsDto()
                                 {
                                     OID = c.OID,
                                     AddictID = c.AddictID,
                                     AddictCode = a.AddictCode,
                                     AddictName = a.LastName + ' ' + a.FirstName,
                                     OtherName = c.OtherName,
                                     ManagePlaceID = c.ManagePlaceID,
                                     ManagePlaceName  = p2.PlaceName,
                                     BlackList = c.BlackList,
                                     DateOfBirth = c.DateOfBirth,

                                     CurrentAddress = c.CurrentAddress,
                                     RelationWithID = c.RelationWithID,
                                     RelationWithName = b.LastName + ' ' + b.FirstName,
                                     Date = c.Date,
                                     RelationsID = c.RelationsID,
                                     RelationsName = p1.RelationName,
                                     
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
