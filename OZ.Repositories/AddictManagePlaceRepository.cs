using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace OZ.Repositories
{
    public class AddictManagePlaceRepository : RepositoryBase<AddictManagePlace>, IAddictManagePlaceRepository
    {
        public AddictManagePlaceRepository(ApplicationContext context) : base(context)
        { }

        public AddictManagePlaceDto SaveCreate(AddictManagePlace domain)
        {
            try
            {
                var us = Create(domain);
                var obj = new AddictManagePlaceDto()
                {
                    OID = us.OID,
                    AddictID = us.AddictID,
                    //AddictCode = a.AddictCode,
                    //AddictName = a.LastName + ' ' + a.FirstName,
                    ManagePlaceID = us.ManagePlaceID,
                    //PlaceName = p2.PlaceName,
                    PlaceTypeID = us.PlaceTypeID,
                    //PlaceTypeName = p1.PlaceTypeName,
                    FromDate = us.FromDate,
                    ToDate = us.ToDate,
                    Remarks = us.Remarks
                };
                return obj;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public new bool Update(AddictManagePlace domain)
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
                AddictManagePlace user = RepositoryContext.AddictManagePlaces.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
        public IEnumerable<AddictManagePlaceDto> GetAll()
        {
            try
            {
                var lst = (from c in RepositoryContext.AddictManagePlaces
                           join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                           join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                           from p1 in ps.DefaultIfEmpty()
                           join l in RepositoryContext.ManagePlaces on c.ManagePlaceID equals l.OID into ps1
                           from p2 in ps1.DefaultIfEmpty()
                           select new AddictManagePlaceDto()
                           {
                               OID = c.OID,
                               AddictID = c.AddictID,
                               AddictCode = a.AddictCode,
                               AddictName = a.LastName + ' ' + a.FirstName,
                               ManagePlaceID = c.ManagePlaceID,
                               PlaceName = p2.PlaceName,
                               PlaceTypeID = c.PlaceTypeID,
                               PlaceTypeName = p1.PlaceTypeName,
                               FromDate = c.FromDate,
                               ToDate = c.ToDate,
                               Remarks = c.Remarks
                           });
                return lst;
                //return RepositoryContext.AddictManagePlaces;//.OrderBy(x => x.PlaceTypeID);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public AddictManagePlaceDto GetByID(Guid id)
        {
            //AddictManagePlace user = RepositoryContext.AddictManagePlaces.Where(x => x.OID.Equals(id)).FirstOrDefault();
            var obj = (from c in RepositoryContext.AddictManagePlaces
                       join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                       join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                       from p1 in ps.DefaultIfEmpty()
                       join l in RepositoryContext.ManagePlaces on c.ManagePlaceID equals l.OID into ps1
                       from p2 in ps1.DefaultIfEmpty()
                       where c.OID.Equals(id)
                       select new AddictManagePlaceDto()
                       {
                           OID = c.OID,
                           AddictID = c.AddictID,
                           AddictCode = a.AddictCode,
                           AddictName = a.LastName + ' ' + a.FirstName,
                           ManagePlaceID = c.ManagePlaceID,
                           PlaceName = p2.PlaceName,
                           PlaceTypeID = c.PlaceTypeID,
                           PlaceTypeName = p1.PlaceTypeName,
                           FromDate = c.FromDate,
                           ToDate = c.ToDate,
                           Remarks = c.Remarks
                       }).FirstOrDefault(); ;

            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortName">field name</param>
        /// <param name="sortDirection"> asc, desc</param>
        /// <param name="searchString">string filter</param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<AddictManagePlaceDto> GetAddictPlaces(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize, IAddictRepository addictRepository)
        {
            if (string.IsNullOrEmpty(searchString))
                searchString = "";

            var lstResult = (from c in FindAll()
                             join a in addictRepository.GetAll() on c.AddictID equals a.OID
                             join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                             from p1 in ps.DefaultIfEmpty()
                             join l in RepositoryContext.ManagePlaces on c.ManagePlaceID equals l.OID into ps1
                             from p2 in ps1.DefaultIfEmpty()
                             where c.Remarks.Contains(searchString) || a.AddictCode.Contains(searchString) || a.FirstName.Contains(searchString)
                             || a.LastName.Contains(searchString) || p1.PlaceTypeName.Contains(searchString) || p2.PlaceName.Contains(searchString)
                             select new AddictManagePlaceDto()
                             {
                                 OID = c.OID,
                                 AddictID = c.AddictID,
                                 AddictCode = a.AddictCode,
                                 AddictName = a.LastName + ' ' + a.FirstName,
                                 ManagePlaceID = c.ManagePlaceID,
                                 PlaceName = p2.PlaceName,
                                 PlaceTypeID = c.PlaceTypeID,
                                 PlaceTypeName = p1.PlaceTypeName,
                                 FromDate = c.FromDate,
                                 ToDate = c.ToDate,
                                 Remarks = c.Remarks
                             });

            //if (!String.IsNullOrEmpty(searchString))
            //    lstResult = lstResult.Where(r => r.a.Remarks.Contains(searchString) || r.PlaceName.Contains(searchString));

            if (!String.IsNullOrEmpty(sortName) && !string.IsNullOrEmpty(sortDirection))
            {
                if (sortDirection.Contains("asc"))
                {
                    switch (sortName)
                    {
                        case nameof(AddictManagePlace.FromDate):
                            lstResult = lstResult.OrderBy(r => r.FromDate);
                            break;
                        case nameof(AddictManagePlace.ToDate):
                            lstResult = lstResult.OrderBy(r => r.ToDate);
                            break;
                        case nameof(AddictManagePlace.Remarks):
                            lstResult = lstResult.OrderBy(r => r.Remarks);
                            break;
                        case "PlaceName":
                            lstResult = lstResult.OrderBy(r => r.PlaceName);
                            break;
                        case "PlaceTypeName":
                            lstResult = lstResult.OrderBy(r => r.PlaceTypeName);
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
                        case nameof(AddictManagePlace.FromDate):
                            lstResult = lstResult.OrderByDescending(r => r.FromDate);
                            break;
                        case nameof(AddictManagePlace.ToDate):
                            lstResult = lstResult.OrderByDescending(r => r.ToDate);
                            break;
                        case nameof(AddictManagePlace.Remarks):
                            lstResult = lstResult.OrderByDescending(r => r.Remarks);
                            break;
                        case "PlaceName":
                            lstResult = lstResult.OrderByDescending(r => r.PlaceName);
                            break;
                        case "PlaceTypeName":
                            lstResult = lstResult.OrderByDescending(r => r.PlaceTypeName);
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
            return PagedList<AddictManagePlaceDto>.ToPagedList((from i in lstResult select i), pageNumber, pageSize);
        }
        //PagedList<AddictManagePlaceDto2>
        public IEnumerable<AddictManagePlaceDto2> GetAddictPlace2(IAddictRepository addictRepository)
        {

            //if (string.IsNullOrEmpty(searchString))
            //    searchString = "";
            //
            var lstResult = (from a in addictRepository.GetAll()
                                 //join p in RepositoryContext.AddictManagePlaces on a.OID equals p.AddictID
                                 //where a.AddictCode.Contains(searchString) || a.FullName.Contains(searchString)
                                 //|| a.LastName.Contains(searchString)

                             select new AddictManagePlaceDto2()
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


            var lst1 = query.ToList();
            foreach (var item in lst1)
            {
                var lstActivitys = (from c in FindAll()
                                    join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                                    from p1 in ps.DefaultIfEmpty()
                                    join l in RepositoryContext.ManagePlaces on c.ManagePlaceID equals l.OID into ps1
                                    from p2 in ps1.DefaultIfEmpty()
                                    where c.AddictID == item.AddictID
                                    select new AddictManagePlaceDto()
                                    {
                                        OID = c.OID,
                                        AddictID = c.AddictID,
                                        ManagePlaceID = c.ManagePlaceID,
                                        PlaceName = p2.PlaceName,
                                        PlaceTypeID = c.PlaceTypeID,
                                        PlaceTypeName = p1.PlaceTypeName,
                                        FromDate = c.FromDate,
                                        ToDate = c.ToDate,
                                        Remarks = c.Remarks
                                    });
                item.ActivityLog = lstActivitys.ToList();
            }
            //return PagedList<AddictManagePlaceDto2>.ToPagedList((lst1.AsQueryable()), pageNumber, pageSize);
            return lst1;
            //groupedCustomerList.AsQueryable()
        }
        public IEnumerable<AddictManagePlaceDto> GetByAddictID(Guid addictID)
        {
            try
            {
                var lst = (from c in FindAll()
                           join a in RepositoryContext.Addicts on c.AddictID equals a.OID
                           join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                           from p1 in ps.DefaultIfEmpty()
                           join l in RepositoryContext.ManagePlaces on c.ManagePlaceID equals l.OID into ps1
                           from p2 in ps1.DefaultIfEmpty()
                           where c.AddictID == addictID
                           select new AddictManagePlaceDto()
                           {
                               OID = c.OID,
                               AddictID = c.AddictID,
                               AddictCode = a.AddictCode,
                               AddictName = a.LastName + ' ' + a.FirstName,
                               ManagePlaceID = c.ManagePlaceID,
                               PlaceName = p2.PlaceName,
                               PlaceTypeID = c.PlaceTypeID,
                               PlaceTypeName = p1.PlaceTypeName,
                               FromDate = c.FromDate,
                               ToDate = c.ToDate,
                               Remarks = c.Remarks
                           });
                return lst;
                //return RepositoryContext.AddictManagePlaces.Where(r => r.AddictID == addictID);//.OrderBy(x => x.PlaceTypeID);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }
    }
}
