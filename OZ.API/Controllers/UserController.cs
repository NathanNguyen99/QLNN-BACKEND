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
    public class UserController : ControllerBase
    {
        IUserMap userMap;
        public UserController(IUserMap map)
        {
            userMap = map;

        }
        // GET api/values
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return userMap.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<UserViewModel> Get(Guid id)
        {
            return userMap.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] UserViewModel user)
        {
            userMap.Update(user);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] UserViewModel user)
        {
            userMap.Create(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            userMap.Delete(id);
        }

        [HttpPost("changePassword")]
        public bool changePassword([FromBody] Newtonsoft.Json.Linq.JObject jObject)
        {
            var userid = Guid.Parse(jObject.GetValue("userid").ToString());
            var opw = jObject.GetValue("oldPassword").ToString();
            var npw = jObject.GetValue("newPassword").ToString();
            return userMap.ChangePassword(userid, opw, npw);

            
        }

        //[HttpPost("changePassword")]
        //public bool changePassword(Guid userid, string oldPassword, string newPassword)
        //{
        //    return userMap.ChangePassword(userid, oldPassword, newPassword);
        //}
    }
}
