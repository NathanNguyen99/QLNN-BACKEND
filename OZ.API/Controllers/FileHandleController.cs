using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OZ.Api.Controllers
{
    [ApiController]

    //[Authorize]
    [Route("api/[controller]")]
    public class FileHandleController : ControllerBase
    {
        //private IWebHostEnvironment _hostEnvironment;

        //public FileUploadController(IWebHostEnvironment environment)
        //{
        //    _hostEnvironment = environment;
        //}
        [HttpGet("AddictImage"), AllowAnonymous]
        public IActionResult Get(string fileName)
        {
            FileStream image = null;
            if (fileName != "null" && fileName != "" && fileName!=null)
            {
                string filepath = Path.Combine(Environment.CurrentDirectory, "images/Addicts/" + fileName);
                if (System.IO.File.Exists(filepath))
                {
                    image = System.IO.File.OpenRead(Path.Combine(Environment.CurrentDirectory, "images/Addicts/" + fileName));
                    return File(image, "image/jpeg");
                }
                return new EmptyResult();
            }
            return new EmptyResult(); 
        }

        [HttpPost("post"), AllowAnonymous]
        public IActionResult Post()
        {
            IFormFileCollection files = Request.Form.Files;
            string uniqueFileName = "";

            if (files.Count > 0)
            {
                var file = files[0];
                uniqueFileName = string.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(file.FileName));

                try
                {
                    var path = Path.Combine(Environment.CurrentDirectory, "images/Addicts/" + uniqueFileName);

                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                catch
                {
                    return BadRequest("Failed to save a file on the server");
                }
            }

            return Ok(uniqueFileName);
        }
    }
}
