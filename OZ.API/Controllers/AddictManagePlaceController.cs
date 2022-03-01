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
    public class AddictManagePlaceController : Controller
    {
        IAddictManagePlaceMap userMap;
        public AddictManagePlaceController(IAddictManagePlaceMap map)
        {
            userMap = map;

        }
        // GET api/Employee
        [HttpGet]
        public IEnumerable<AddictManagePlaceViewModel> Get()
        {
            return userMap.GetAll(); ;
        }
        // GET api/user/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }
        [HttpGet("GetByAddictID")]
        public IEnumerable<AddictManagePlaceViewModel> GetByAddictID(Guid adID)
        {
            return userMap.GetByAddictID(adID);
        }
        [HttpGet("GetPaging")]
        public IActionResult GetPaging(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            var res = userMap.GetAddictPlaces(sortName, sortDirection, searchString, pageNumber, pageSize);
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
        [HttpGet("GetPaging2")]
        public IEnumerable<AddictManagePlaceViewModel2> GetPaging2()
        {
            var res = userMap.GetAddictPlace2();
            return res;

        }
        // POST api/user
        [HttpPost]
        public void Post([FromBody] AddictManagePlaceViewModel user)
        {
            userMap.Update(user);
        }
        // PUT api/user/5
        [HttpPut]
        public void Put([FromBody] AddictManagePlaceViewModel user)
        {
            userMap.Create(user);
        }
        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            userMap.Delete(id);
        }
    }
}
