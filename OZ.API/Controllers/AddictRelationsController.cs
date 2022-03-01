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
    public class AddictRelationsController : Controller
    {
        IAddictRelationsMap userMap;
        public AddictRelationsController(IAddictRelationsMap map)
        {
            userMap = map;
            
        }
        // GET api/Employee
        [HttpGet]
        public IEnumerable<AddictRelationsViewModel> Get()
        {
            return userMap.GetAll(); ;
        }
        // GET api/user/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }
        [HttpGet("GetPaging")]
        public IActionResult GetPaging(string sortName, string sortDirection, string searchString, int pageNumber, int pageSize)
        {
            var res = userMap.GetAddictRelations(sortName, sortDirection, searchString, pageNumber, pageSize);
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
        public IEnumerable<AddictRelationsViewModel2> GetPaging2()
        {
            var res = userMap.GetAddictRelations2();
            return res;

        }
        [HttpGet("GetByAddictID")]
        public IEnumerable<AddictRelationsViewModel> GetByAddictID(Guid adID)
        {
            return userMap.GetByAddictID(adID);
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody]AddictRelationsViewModel user)
        {
            userMap.Update(user);
        }
        // PUT api/user/5
        [HttpPut]
        public void Put([FromBody] AddictRelationsViewModel user)
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
