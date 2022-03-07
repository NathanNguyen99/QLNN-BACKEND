using Microsoft.EntityFrameworkCore;
using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZ.Repositories
{
    public class DashRepository : RepositoryBase, IDashRepository
    {
        public DashRepository(ApplicationContext context) : base(context)
        {
        }
        //[System.Obsolete("Use DbSet<T> instead")]
        //async Task<List<Dash01>
        public IEnumerable<Dash01> GetDashBoard01(IAddictRepository addictRepository)
        {
            List<Dash01> lst = null;
            try
            {
                var lstResult = from x in addictRepository.GetAll()
                                where x.CreateDate > DateTime.Now.AddMonths(-12)
                                 group x by new { month = x.CreateDate.Month, year = x.CreateDate.Year } into y
                                 select new Dash01()
                                 {
                                     MonthID = string.Format("{0}/{1}", y.Key.month, y.Key.year),
                                     Qty = y.Count(),
                                 };
                return lstResult;
                //Processing.
                //string sqlQuery = "EXEC [dbo].[spDash01]";
                //lst = await RepositoryContext.Dash01s.FromSqlRaw(sqlQuery).ToListAsync();

            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        public IEnumerable<Dash02> GetDashBoard02(IAddictRepository addictRepository)
        {
            List<Dash02> lst = null;
            try
            {
               
                var currYear = DateTime.Now.Year;
                var male = (from x in addictRepository.GetAll()
                            where x.GenderID == 0 && (x.Complete == null || x.Complete == false) && (x.CreateDate.Year == currYear - 1)
                            select x.OID).Count();
                var female = (from x in addictRepository.GetAll()
                              where x.GenderID == 1 && (x.Complete == null || x.Complete == false) && (x.CreateDate.Year == currYear - 1)
                              select x).Count();
                List<Dash02> lstResult = new List<Dash02>()
                {
                    new Dash02() { male=male, female=female, Syear=(currYear-1).ToString()}
                };
                return lstResult;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        public async Task<List<Dash03>> GetDashBoard03()
        {
            List<Dash03> lst = null;
            try
            {
                // Processing.

                string sqlQuery = "EXEC [dbo].[spDashGrug]";
                lst = await RepositoryContext.Dash03s.FromSqlRaw(sqlQuery).ToListAsync();


            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        public IEnumerable<Dash04> GetDashBoard04(IAddictRepository addictRepository)
        {
            List<Dash04> lst = null;
            try
            {
                var lstResult = from x in addictRepository.GetAll()
                                join y in RepositoryContext.EducationLevels on x.EducationLevelID equals y.OID
                                group x by new { EducationLevel = y.EducationName, } into g
                                select new Dash04()
                                {
                                    levelName = g.Key.EducationLevel,
                                    Qty = g.Count()
                                };
                return lstResult;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        public IEnumerable<Dash05> GetDashBoard05(IAddictRepository addictRepository)
        {
            List<Dash05> lst = null;
            try
            {
                //&& (x.CreateDate.Year == currYear)
                var currYear = DateTime.Now.Year;
                var currBelow16 = (from x in addictRepository.GetAll()
                                   where (currYear - x.YearOfBirth) < 16 && (x.CreateDate.Year == currYear)
                               select x.OID).Count();
                var preBelow16 = (from x in addictRepository.GetAll()
                                  where (currYear - x.YearOfBirth) < 16 && (x.CreateDate.Year == currYear - 1)
                               select x.OID).Count();
                var curr16To18 = (from x in addictRepository.GetAll()
                                  where (currYear - x.YearOfBirth >= 16) && (currYear - x.YearOfBirth < 18) && (x.CreateDate.Year == currYear)
                                   select x.OID).Count();
                var pre16To18 = (from x in addictRepository.GetAll()
                                 where (currYear - x.YearOfBirth >= 16) && (currYear - x.YearOfBirth < 18) && (x.CreateDate.Year == currYear - 1)
                                  select x.OID).Count();
                var curr18To25 = (from x in addictRepository.GetAll()
                                  where (currYear - x.YearOfBirth >= 18) && (currYear - x.YearOfBirth < 25) && (x.CreateDate.Year == currYear)
                                   select x.OID).Count();
                var pre18To25 = (from x in addictRepository.GetAll()
                                 where (currYear - x.YearOfBirth >= 18) && (currYear - x.YearOfBirth < 25) && (x.CreateDate.Year == currYear - 1)
                                  select x.OID).Count();
                var currAbove25 = (from x in addictRepository.GetAll()
                                   where (currYear - x.YearOfBirth >= 25) && (x.CreateDate.Year == currYear)
                                  select x.OID).Count();
                var preAbove25 = (from x in addictRepository.GetAll()
                                  where (currYear - x.YearOfBirth >= 25) && (x.CreateDate.Year == currYear - 1)
                                 select x.OID).Count();
                List<Dash05> lstResult = new List<Dash05>()
                {
                    new Dash05() { AgeRange="Dưới 16", curQty=currBelow16, PreQty=preBelow16},
                    new Dash05() { AgeRange="Từ 16-18", curQty=curr16To18, PreQty=pre16To18},
                    new Dash05() { AgeRange="Từ 18-25", curQty=curr18To25, PreQty=pre18To25},
                    new Dash05() { AgeRange="Trên 25", curQty=currAbove25, PreQty=preAbove25},
                };

                return lstResult;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }


        public IEnumerable<DashClassify> GetDashBoardClassify(IAddictClassifyRepository addictClassifyRepository, IAddictRepository addictRepository)
        {
            List<DashClassify> lst = null;
            try
            {
                //                select ClassifyName, count(B.OID) as Qty
                //from AddictClassify as A inner join Classify as B on A.ClassifyID = B.OID
                //Group by ClassifyName

                var lstResult = from x in addictClassifyRepository.GetAll(addictRepository)
                                join y in RepositoryContext.Classifys on x.ClassifyID equals y.OID
                                group x by new { ClassifyName = y.ClassifyName} into g
                                select new DashClassify()
                                {
                                    classifyName = g.Key.ClassifyName,
                                    Qty = g.Count()
                                };
                return lstResult;
                // Processing.
                                //string sqlQuery = "exec [dbo].[spDashAddictClassify]";
                                //lst = await RepositoryContext.DashClassifys.FromSqlRaw(sqlQuery).ToListAsync();

            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        public IEnumerable<DashAddictType> GetDashBoardAddictType()
        {
            List<DashAddictType> lst = null;
            try
            {
                
                var lstResult = (from x in RepositoryContext.ManagePlaces
                                 join y in RepositoryContext.Addicts on x.OID equals y.ManagePlaceID
                                 group x by new { PlaceName = x.PlaceName } into g
                                 orderby g.Count() descending
                                 select new DashAddictType()
                                 {  
                                     PlaceName = g.Key.PlaceName,
                                     Qty = g.Count()
                                 }).Take(10);
                return lstResult;                

            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        //IEnumerable<Dash01> IDashRepository.GetDashBoard01()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
