using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Web;

using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace OZ.Repositories
{
    public class ManageCityRepository : RepositoryBase<ManageCity>, IManageCityRepository
    {

        public ManageCityRepository(ApplicationContext context) : base(context)
        { }




        public IEnumerable<ManageCity> GetAll()
        {
            try
            {
               
                return FindAll();
                //return RepositoryContext.ManagePlaces.OrderBy(x => x.PlaceTypeID);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

    }
}
