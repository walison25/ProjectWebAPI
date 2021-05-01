using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Lib;
using ProjectWeb.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolContext _SchoolContext;
        public CoursesController(SchoolContext SchoolContext)
        {
            _SchoolContext = SchoolContext;
        }


        // GET: api/<CoursesController>
        [HttpGet]
        public JsonResult Get()
        {
            
            return new JsonResult(_SchoolContext.Course.ToList());
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_SchoolContext.Course.Where(sc => sc.IdCourse == id));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public void Post([FromBody] Course Course)
        {
            _SchoolContext.Course.Add(Course);

          
            _SchoolContext.SaveChanges();
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Course Course)
        {
            _SchoolContext.Course.Update(Course);
              
                  
            _SchoolContext.SaveChanges();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var course = _SchoolContext.Course.Find(id);

            _SchoolContext.Course.Remove(course);
            _SchoolContext.SaveChanges();
        }
    }
}
