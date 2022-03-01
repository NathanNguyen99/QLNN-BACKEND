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
    public class DrugsController : Controller
    {
        IDrugsMap userMap;
        public DrugsController(IDrugsMap map)
        {
            userMap = map;
            
        }
        // GET api/Employee
        [HttpGet]
        public IEnumerable<DrugsViewModel> Get()
        {
            return userMap.GetAll(); ;
        }
        // GET api/user/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }
        // POST api/user
        [HttpPost]
        public void Post([FromBody]DrugsViewModel user)
        {
            userMap.Update(user);
        }
        // PUT api/user/5
        [HttpPut]
        public void Put([FromBody]DrugsViewModel user)
        {
            userMap.Create(user);
        }
        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userMap.Delete(id);

        }
    }
}
