using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OZ.Interfaces;
using OZ.ViewModels;

namespace OZ.Api.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController, Authorize]
    public class UsesController : ControllerBase
    {
        IUsesMap userMap;
        public UsesController(IUsesMap map)
        {
            userMap = map;

        }
        // GET api/values
        [HttpGet]
        public IEnumerable<UsesViewModel> Get()
        {
            return userMap.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UsesViewModel> Get(Guid id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] UsesViewModel user)
        {
            userMap.Update(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UsesViewModel user)
        {
            userMap.Create(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userMap.Delete(id);
        }
    }
}
