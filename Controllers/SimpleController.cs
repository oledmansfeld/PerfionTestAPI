using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimpleController : ControllerBase
    {
        //Create a get method that returns a string
        [HttpGet]
        [Produces("application/json")]
        public JsonResult Get()
        {
            

            MyData myData = new MyData()
            {
                Host = @"sftp.myhost.gr",
                UserName = "my_username",
                Password = "my_password",
                SourceDir = "/export/zip/mypath/",
                FileName = "my_file.zip"
            };

            UserData user = new UserData()
            {
                User = myData
            };

            JsonResult jsonResult = new JsonResult(user);
         
            return jsonResult;
        }

        //Create a post method that returns a string
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody]JsonValue value)
        {
            return Ok(value);
        }
    }
    
    [Produces("application/json")]
    public class MyData
    {
        public string? Host { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? SourceDir { get; set; }
        public string? FileName { get; set; }
    }

    public class UserData() {
        public MyData User { get; set; }
    }
}