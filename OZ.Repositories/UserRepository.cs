using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZ.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        { }

        public new UserDto SaveCreate(User domain)
        {
            try
            {
                var us = Create(domain);
                var obj = new UserDto()
                {
                    OID = us.OID,
                    UserName = us.UserName,
                    FullName = us.FullName,
                    Active = us.Active,
                    Password = us.Password,
                    Admin = us.Admin,
                    PlaceID = us.PlaceID,
                    ManageCityID = us.ManageCityID,
                    ManageCityTypeID = us.ManageCityTypeID,
                };
                return obj;
                //return us;
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
        public new bool Update(User domain)
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
                User user = RepositoryContext.AppUsers.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
        public IEnumerable<UserDto> GetAll()
        {
            try
            {
                var lst = (from c in RepositoryContext.AppUsers
                           join p in RepositoryContext.ManagePlaces on c.PlaceID equals p.OID into ps
                           from p1 in ps.DefaultIfEmpty()
                           join l in RepositoryContext.ManageCityType on c.ManageCityTypeID equals l.OID into ps2
                           from p2 in ps2.DefaultIfEmpty()
                           join e in RepositoryContext.ManageCity on c.ManageCityID equals e.OID into ps3
                           from p3 in ps3.DefaultIfEmpty()
                           select new UserDto()
                           {
                        
                                OID = c.OID,
                               UserName = c.UserName,
                               FullName = c.FullName,
                               Password = c.Password,
                               Admin = c.Admin,
                               Active = c.Active,
                               PlaceID = c.PlaceID,
                               PlaceName = p1.PlaceName,
                               ManageCityID = c.ManageCityID,
                               ManageCityTypeID = c.ManageCityTypeID,
                               ManageCityTypeName = p2.ManageCityTypeName,
                               ManageCityName = p3.CityName
                           });
                return lst;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public UserDto GetByID(Guid id)
        {
            var objResult = (from c in FindAll()

                             join e in RepositoryContext.AppUsers on c.OID equals e.OID into ps2
                             from p2 in ps2.DefaultIfEmpty()
                             join l in RepositoryContext.ManageCityType on c.ManageCityTypeID equals l.OID into ps3
                             from p3 in ps3.DefaultIfEmpty()
                             join e in RepositoryContext.ManageCity on c.ManageCityID equals e.OID into ps4
                             from p4 in ps4.DefaultIfEmpty()
                             select new UserDto()
                             {
                                 OID = c.OID,
                                 UserName = c.UserName,
                                 FullName = c.FullName,
                                 Password = c.Password,
                                 Admin = c.Admin,
                                 Active = c.Active,
                                 PlaceID = c.PlaceID,
                                 ManageCityID = c.ManageCityID,
                                 ManageCityTypeID = c.ManageCityTypeID,
                                 ManageCityTypeName = p3.ManageCityTypeName,
                                 ManageCityName = p4.CityName

                             }).FirstOrDefault();
            //User user = RepositoryContext.AppUsers.Where(x => x.OID.Equals(id)).FirstOrDefault();
            if (objResult != null)
            {
                objResult.PlaceName = GetPlaceName(objResult.PlaceID);
                return objResult;
            }
            else
            {

            }
            {
                return null;
            }
        }

        public string GetPlaceName(Guid? oid)
        {
            string strvalue = string.Empty;
            var obj = RepositoryContext.ManagePlaces.FirstOrDefault(r => r.OID == oid);
            if (obj != null)
                strvalue = obj.PlaceName;
            return strvalue;
        }

        public UserDto CheckLogin(string username, string password)
        {
            UserDto user = (from c in RepositoryContext.AppUsers
                            join p in RepositoryContext.ManagePlaces on c.PlaceID equals p.OID into ps
                            from p1 in ps.DefaultIfEmpty()
                            join l in RepositoryContext.ManageCityType on c.ManageCityTypeID equals l.OID into ps3
                            from p3 in ps3.DefaultIfEmpty()
                            join e in RepositoryContext.ManageCity on c.ManageCityID equals e.OID into ps4
                            from p4 in ps4.DefaultIfEmpty()
                            where c.UserName == username && c.Password == password
                           select new UserDto()
                           {
                               OID = c.OID,
                               UserName = c.UserName,
                               FullName = c.FullName,
                               Password = c.Password,
                               Admin = c.Admin,
                               Active = c.Active,
                               PlaceID = c.PlaceID,
                               PlaceName = p1.PlaceName,
                               ManageCityID = c.ManageCityID,
                               ManageCityTypeID = c.ManageCityTypeID,
                               ManageCityTypeName = p3.ManageCityTypeName,
                               ManageCityName = p4.CityName
                           }).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public bool ChangePassword(Guid userid, string oldPassword, string newPassword)
        {
            try
            {
                User user = FindByCondition(x => x.OID.Equals(userid) && x.Password.Equals(oldPassword)).FirstOrDefault();
                if (user!=null)
                {
                    user.Password = newPassword;
                    base.Update(user);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return false;                
            }
        }
    }
}
