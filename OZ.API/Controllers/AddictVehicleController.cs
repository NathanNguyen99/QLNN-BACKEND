using OZ.Interfaces;
using OZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace OZ.Api.Controllers
{
    [Route("api/[controller]")]
    
    [Authorize]
    public class AddictVehicleController : Controller
    {
        IAddictVehicleMap userMap;
        public AddictVehicleController(IAddictVehicleMap map)
        {
            userMap = map;
            
        }
        [HttpGet]
        public IEnumerable<AddictVehicleViewModel> Get()
        {
            return userMap.GetAll(); ;
        }
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }
        [HttpGet("GetByAddictID")]
        public IEnumerable<AddictVehicleViewModel> GetByAddictID(Guid adID)
        {
            return userMap.GetByAddictID(adID);
        }
        [HttpGet("GetPaging")]
        public IActionResult GetPaging(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            var res = userMap.GetAddictVehicle(sortName, sortDirection, searchString, pageNumber, pageSize);
            var metadata = new
            {
                res.TotalCount,
                res.PageSize,
                res.CurrentPage,
                res.TotalPages,
                res.HasNext,
                res.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(new
            {                
                TotalCount = res.TotalCount,
                items = res
            });

        }
        [HttpPost]
        public void Post([FromBody]AddictVehicleViewModel user)
        {
            userMap.Update(user);
        }
        [HttpPut]
        public void Put([FromBody]AddictVehicleViewModel user)
        {
            userMap.Create(user);
        }
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            userMap.Delete(id);
        }
    }
}
