using OZ.Interfaces;
using OZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Data;
using ExcelDataReader;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using OZ.Models;
using Microsoft.AspNetCore.Cors;
using ClosedXML.Excel;

namespace OZ.Api.Controllers
{
    [Route("api/[controller]")]
  
    [Authorize]
    public class ManagePlaceController : Controller
    {
        private IWebHostEnvironment Environment;
        IManagePlaceMap userMap;
        public ManagePlaceController(IWebHostEnvironment _environment, IManagePlaceMap map)
        {
            userMap = map;
            Environment = _environment;
        }
        // GET api/Employee
        [HttpGet]
        public IEnumerable<ManagePlaceViewModel> Get()
        {
            return userMap.GetAll();
        }
        // GET api/Employee
        [HttpGet("GetByType")]
        public IEnumerable<ManagePlaceViewModel> Get(int citytyp, int typeid)
        {
            if (typeid == 0)
                return userMap.GetAll();
            return userMap.GetByType(typeid, citytyp);
        }
        [HttpGet("GetPaging")]
        public IActionResult GetPaging(int pageNumber, int pageSize)
        {
            int totalPages = 0;
            int totalRecords = 0;
            var res= userMap.GetPaging("", pageNumber, pageSize, out totalPages, out totalRecords);

            //return res;
            return Ok(new {
                totalPage = totalPages,
                TotalCount = totalRecords,
                items = res
            });
        }
        // GET api/user/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }
        // POST api/user
        [HttpPost]
        public void Post([FromBody]ManagePlaceViewModel user)
        {
            userMap.Update(user);
        }

        [HttpPost("UploadExcel")]
        [Consumes("multipart/form-data")]
        public IActionResult UploadExcel([FromForm]IFormFile FileUpload)
        {   
            userMap.UploadExcel(FileUpload);    
            return Ok();
        }

        [HttpGet("ExportExcel")]
        public HttpResponseMessage Export()
        {
            return userMap.ExportExcel();

            //return Ok();
        }

        [HttpGet("ExportExcel2")]
        public IActionResult Export2()
        {

                DataTable dt = new DataTable("Nơi quản lý");
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Phường, xã, Thị Trấn"),
                                        new DataColumn("Địa chỉ"),
                                        new DataColumn("Loại quản lý"),
                                        new DataColumn("Thuộc vùng quản lý") });

                //.Take(10)
                //var ManagePlaces = from customer in RepositoryContext.ManagePlaces
                //                   select customer;
                var ManagePlaces = Get();
                foreach (var ManagePlace in ManagePlaces)
                {
                    dt.Rows.Add(ManagePlace.PlaceName, ManagePlace.Address, ManagePlace.PlaceTypeID, ManagePlace.ManageCityID);
                }
                //
                using (XLWorkbook wb = new XLWorkbook())
                {   
                    wb.Worksheets.Add(dt);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                    }
                }
        }

        // PUT api/user/5
        [HttpPut]
        public void Put([FromBody]ManagePlaceViewModel user)
        {
            userMap.Create(user);
        }
        // DELETE api/user/5    userMap.Delete(id);
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            userMap.Delete(id);
        }
    }
}
