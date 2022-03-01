using OZ.Interfaces;
using OZ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace OZ.Api.Controllers
{
    [Route("api/[controller]")]
  
    [Authorize]
    public class ProvinceController : Controller
    {
        IProvinceMap userMap;
        public ProvinceController(IProvinceMap map)
        {
            userMap = map;
        }
        // GET api/Province
        [HttpGet]
        public IEnumerable<ProvinceViewModel> Get()
        {
            return userMap.GetAll();
        }
        // GET api/user/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }
        // POST api/user
        [HttpPost]
        public void Post([FromBody]ProvinceViewModel user)
        {
            userMap.Update(user);
        }
        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProvinceViewModel user)
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
