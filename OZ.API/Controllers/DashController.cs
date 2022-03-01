using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OZ.Interfaces;
using OZ.ViewModels;

namespace OZ.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController, Authorize]
    public class DashController : ControllerBase
    {
        IDashboardMap iMap;
        public DashController(IDashboardMap map)
        {
            iMap = map;

        }
        // GET api/values
        [HttpGet("DB01")]
        public IEnumerable<DashViewModel01> Get()
        {            
            return iMap.GetDashBoard01();
        }
        [HttpGet("DB02")]
        public IEnumerable<DashViewModel02> GetDB2()
        {
            return iMap.GetDashBoard02();
        }
        [HttpGet("DB03")]
        public IEnumerable<DashViewModel03> GetDB3()
        {
            return iMap.GetDashBoard03();
        }
        [HttpGet("DB04")]
        public IEnumerable<DashViewModel04> GetDB4()
        {
            return iMap.GetDashBoard04();
        }
        [HttpGet("DB05")]
        public IEnumerable<DashViewModel05> GetDB5()
        {
            return iMap.GetDashBoard05();
        }
        [HttpGet("DBClassify")]
        public IEnumerable<DashViewModelClassify> GetDBClassify()
        {
            return iMap.GetDashBoardClassify();
        }
        [HttpGet("DBAddictType")]
        public IEnumerable<DashViewModelAddictType> GetDBAddictType()
        {
            return iMap.GetDashBoardAddictType();
        }   
    }
}

