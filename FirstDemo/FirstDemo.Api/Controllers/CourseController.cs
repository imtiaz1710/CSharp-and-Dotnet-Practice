using FirstDemo.Api.Models;
using FirstDemo.Common.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(Policy = "AccessPermission")]
    //[EnableCors("AllowSites")]
    public class CourseController : ControllerBase
    {
        // GET: api/<CourseController>
        [HttpGet]
        public object Get()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new CourseListModel();
            var data = model.GetCourses(dataTablesModel);
            return data;
        }
       
        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
