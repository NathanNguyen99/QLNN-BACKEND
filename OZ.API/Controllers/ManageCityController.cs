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

namespace OZ.Api.Controllers
{
    [Route("api/[controller]")]
    
    [Authorize]
    public class ManageCityController : Controller
    {
      
        IManageCityMap userMap;
        public ManageCityController(IManageCityMap map)
        {
            userMap = map;
        }
        // GET api/Employee
        [HttpGet]
        public IEnumerable<ManageCityViewModel> Get()
        {
            return userMap.GetAll();
        }
        // GET api/Employee
        
    }
}
