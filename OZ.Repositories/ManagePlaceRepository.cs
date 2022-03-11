using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.MVC;

using Microsoft.EntityFrameworkCore;
using OZ.Interfaces;
using OZ.Models;
using OZ.Models.Context;
using System;
using System.Web;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Data.SqlClient;
using System.Data.OleDb;
using LinqToExcel;
using System.Data.Entity.Validation;
using ClosedXML.Excel;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using AppContext = OZ.Models.Context.Helpers.AppContext;

namespace OZ.Repositories
{
    public class ManagePlaceRepository : RepositoryBase<ManagePlace>, IManagePlaceRepository
    {
        
        public ManagePlaceRepository(ApplicationContext context, IConfiguration configuration) : base(context)
        { Configuration = configuration;
          

        }
        public IConfiguration Configuration { get; }

        public ManagePlaceDto SaveCreate(ManagePlace domain)
        {
            try
            {
                var us = Create(domain);
                var oPlace = new ManagePlaceDto() { OID = us.OID, PlaceName = us.PlaceName, Address = us.Address, PlaceTypeID = us.PlaceTypeID };

                oPlace.PlaceTypeName = GetPlaceTypeName(oPlace.PlaceTypeID);

                    return oPlace;
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }


        public HttpResponseMessage ExportExcel()
        {
            try
            {
                DataTable dt = new DataTable("Grid");
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("PlaceName"),
                                        new DataColumn("Address"),
                                        new DataColumn("PlaceTypeID"),
                                        new DataColumn("ManageCityID") });

                //.Take(10)
                var ManagePlaces = from customer in RepositoryContext.ManagePlaces
                                select customer;

                foreach (var ManagePlace in ManagePlaces)
                {
                    dt.Rows.Add(ManagePlace.PlaceName, ManagePlace.Address, ManagePlace.PlaceTypeID, ManagePlace.ManageCityID);
                }

                

                XLWorkbook wb = new XLWorkbook();
                {
                    wb.Worksheets.Add(dt);
                    MemoryStream stream = new MemoryStream();
                    {       
                        wb.SaveAs(stream);
                        stream.Position = 0;
                        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(stream.ToArray())
                        }; 
                        //result.Content = new StreamContent(stream);
                        //result.Content = new ByteArrayContent(stream.ToArray());          

                        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                        result.Content.Headers.ContentDisposition.FileName = "Grid.xlsx";
                        //"application/octet-stream"
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                        result.Content.Headers.ContentLength = stream.Length;
                        return result;
                    }
                }   
                
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }
        
        public bool UploadExcel(IFormFile postedFile)
        {
            //Create a Folder.
            string path1 = @"C:\Users\Oryza\Desktop\QLNN\Excel Files";
            string path = Path.Combine(path1, "temp1");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Save the uploaded Excel file.
            string fileName = Path.GetFileName(postedFile.FileName);
            string filePath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                postedFile.CopyTo(stream);
            }

            var connectionString = "";

            if (fileName.EndsWith(".xls"))
            {
                connectionString = string.Format(Configuration.GetValue<string>("ExcelFormat:xls"), filePath);
            }
            else if (fileName.EndsWith(".xlsx"))
            {
                connectionString = string.Format(Configuration.GetValue<string>("ExcelFormat:xlsx"), filePath);
            }
            var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$] ", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "ExcelTable");
            DataTable dtable = ds.Tables["ExcelTable"];

            //Set the Sheet name over here
            string sheetName = "Sheet1";

            var excelFile = new ExcelQueryFactory(filePath);
            var artistAlbums = from a in excelFile.Worksheet<ManagePlace>(sheetName) select a ;
            
            foreach (var a in artistAlbums)
            {
                try
                {
                    ManagePlace TU = new ManagePlace() { PlaceName = a.PlaceName, Address = a.Address, PlaceTypeID = a.PlaceTypeID, ManageCityID = a.ManageCityID };
                    
                    Create(TU);
                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Commons.NLogAction.instance.logger.Error("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
            }   
            return false;

        }
        public new bool Update(ManagePlace domain)
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
                ManagePlace user = RepositoryContext.ManagePlaces.Where(x => x.OID.Equals(id)).FirstOrDefault();
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
        public IEnumerable<ManagePlaceDto> GetAll()
        {
            try
            {   
                var lst = (from c in RepositoryContext.ManagePlaces
                           join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                           from p1 in ps.DefaultIfEmpty()
                           orderby c.PlaceName 
                           select new ManagePlaceDto() { OID = c.OID,
                               PlaceName = c.PlaceName,
                               Address = c.Address,
                               PlaceTypeID = c.PlaceTypeID,
                               PlaceTypeName = p1.PlaceTypeName,
                            ManageCityID = c.ManageCityID});
                return lst;
                //return RepositoryContext.ManagePlaces.OrderBy(x => x.PlaceTypeID);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public ManagePlaceDto GetByID(Guid id)
        {
            var objResult = (from c in FindAll()

                             join e in RepositoryContext.ManagePlaces on c.OID equals e.OID into ps2
                             from p2 in ps2.DefaultIfEmpty()

                             select new ManagePlaceDto()
                             {
                                 OID = c.OID,
                                 PlaceName = c.PlaceName,
                                 Address = c.Address,
                                 PlaceTypeID = c.PlaceTypeID,
                                 ManageCityID = c.ManageCityID
                             }).FirstOrDefault();
            

            if (objResult!= null)
            {
                objResult.PlaceTypeName = GetPlaceTypeName(objResult.PlaceTypeID);
                return objResult;
            }
            else
            {
                return null;
            }
            
        }

        public string GetPlaceTypeName(int oid)
        {
            string strvalue = string.Empty;
            var obj = RepositoryContext.PlaceTypes.FirstOrDefault(r => r.OID == oid);
            if (obj != null)
                strvalue = obj.PlaceTypeName;
            return strvalue;
        }

        public IEnumerable<ManagePlaceDto> GetByType(int typ, int citytyp)
        {
            try
            {

                var _placeID = new Guid(AppContext.Current.User.FindFirst("PlaceID").Value);

                var getPlaceName = (from c in RepositoryContext.AppUsers
                                    join b in RepositoryContext.ManagePlaces on c.PlaceID equals b.OID
                                    where c.PlaceID == _placeID
                                    select b.PlaceName).FirstOrDefault();
                //highest level
                if (getPlaceName == "Admin")
                {

                    if (citytyp == 10)
                    {
                        var lst1 = (from c in RepositoryContext.ManagePlaces
                                   join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                                   from p1 in ps.DefaultIfEmpty()
                                   orderby c.PlaceName
                                   where c.PlaceTypeID == typ 
                                   select new ManagePlaceDto()
                                   {    
                                       OID = c.OID,
                                       PlaceName = c.PlaceName,
                                       Address = c.Address,
                                       PlaceTypeID = c.PlaceTypeID, 
                                       PlaceTypeName = p1.PlaceTypeName,
                                       ManageCityID = c.ManageCityID
                                   });
                        return lst1;
                    }
                    var lst2 = (from c in RepositoryContext.ManagePlaces
                                join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                                from p1 in ps.DefaultIfEmpty()
                                orderby c.PlaceName
                                where c.PlaceTypeID == typ && c.ManageCityID == citytyp
                                select new ManagePlaceDto()
                                {
                                    OID = c.OID,
                                    PlaceName = c.PlaceName,
                                    Address = c.Address,
                                    PlaceTypeID = c.PlaceTypeID,
                                    PlaceTypeName = p1.PlaceTypeName,
                                    ManageCityID = c.ManageCityID
                                });
                    return lst2;
                }
                var lst3 = (from c in RepositoryContext.ManagePlaces
                            join p in RepositoryContext.PlaceTypes on c.PlaceTypeID equals p.OID into ps
                            from p1 in ps.DefaultIfEmpty()
                            orderby c.PlaceName
                            where c.OID == _placeID
                            select new ManagePlaceDto()
                            {
                                OID = c.OID,
                                PlaceName = c.PlaceName,
                                Address = c.Address,
                                PlaceTypeID = c.PlaceTypeID,
                                PlaceTypeName = p1.PlaceTypeName,
                                ManageCityID = c.ManageCityID
                            });
                return lst3;

            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public async Task<IEnumerable<ManagePlace>> GetPagingAsync(string fieldOrder, int pageNumber, int pageSize)
        {
            try
            {
                //// var pagedData = await context.Customers
                ////.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                ////.Take(validFilter.PageSize)
                ////.ToListAsync();
                //totalRecords = RepositoryContext.ManagePlaces.Count();
                //totalPages=  (int)Math.Ceiling(totalRecords / (double)pageSize);
                return await RepositoryContext.ManagePlaces.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                return null;
            }
        }

        public  IEnumerable<ManagePlace> GetPaging(string fieldOrder, int pageNumber, int pageSize, out int totalPages, out int totalRecords)
        {
            try
            {
                totalRecords = RepositoryContext.ManagePlaces.Count();
                totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

                return RepositoryContext.ManagePlaces.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                Commons.NLogAction.instance.logger.Error(ex);
                totalRecords = 0;
                totalPages = 0;
                return null;
            }
        }




        //IEnumerable<ManagePlace> IManagePlaceRepository.GetPagingAsync(string fieldOrder, int pageNumber, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
