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
        public async Task<List<Dash01>> GetDashBoard01()
        {
            // Initialization.
            List<Dash01> lst = null;

            try
            {
                // Processing.
                string sqlQuery = "EXEC [dbo].[spDash01]";
                lst = await RepositoryContext.Dash01s.FromSqlRaw(sqlQuery).ToListAsync();
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        public async Task<List<Dash02>> GetDashBoard02()
        {
            List<Dash02> lst = null;
            try
            {
                // Processing.
                
                string sqlQuery = "EXEC [dbo].[spDashGender]";
                lst = await RepositoryContext.Dash02s.FromSqlRaw(sqlQuery).ToListAsync();

                
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

        public async Task<List<Dash04>> GetDashBoard04()
        {
            List<Dash04> lst = null;
            try
            {
                // Processing.

                string sqlQuery = "EXEC [dbo].[spDashLevel]";
                lst = await RepositoryContext.Dash04s.FromSqlRaw(sqlQuery).ToListAsync();


            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        public async Task<List<Dash05>> GetDashBoard05()
        {
            List<Dash05> lst = null;
            try
            {
                // Processing.

                string sqlQuery = "EXEC [dbo].[spDashAgeRange]";
                lst = await RepositoryContext.Dash05s.FromSqlRaw(sqlQuery).ToListAsync();


            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        public async Task<List<DashClassify>> GetDashBoardClassify()
        {
            List<DashClassify> lst = null;
            try
            {
                // Processing.

                string sqlQuery = "exec [dbo].[spDashAddictClassify]";
                lst = await RepositoryContext.DashClassifys.FromSqlRaw(sqlQuery).ToListAsync();


            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
            }
            // Info.
            return lst;
        }

        public async Task<List<DashAddictType>> GetDashBoardAddictType()
        {
            List<DashAddictType> lst = null;
            try
            {
                // Processing.

                string sqlQuery = "exec [dbo].[spDashAddictType]";
                lst = await RepositoryContext.DashAddictTypes.FromSqlRaw(sqlQuery).ToListAsync();


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
