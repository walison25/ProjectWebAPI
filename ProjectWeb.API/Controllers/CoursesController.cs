using Microsoft.AspNetCore.Mvc;
using ProjectWeb.Lib;
using ProjectWeb.Lib.Models;
using System.Linq;

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
            if (_SchoolContext.Course.Count() > 0) 
            {
                return new JsonResult(_SchoolContext.Course.ToList());
            }
            else
            {
                return new JsonResult("Empty object, please check.");
            }
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var course = _SchoolContext.Course.Where(sc => sc.IdCourse == id);
            if (course.Count() == 0)
            {
                return new JsonResult("The id you entered does not exist in the database.");
            }
            else
            {
                return new JsonResult(course);
            } 
        }

        // POST api/<CoursesController>
        [HttpPost]
        public JsonResult Post([FromBody] Course Course)
        {
            var course = _SchoolContext.Course.Where(sc => sc.IdCourse == Course.IdCourse);
            if (course.Count() > 0)
            {
                return new JsonResult("This id already exists in the database, please check");
            }
            else
            {
                _SchoolContext.Course.Add(Course);
                _SchoolContext.SaveChanges();
                return new JsonResult("Saved successfully");
            }
            
        }

        // PUT api/<CoursesController>/5
        [HttpPut]
        public JsonResult Put([FromBody] Course Course)
        {
            var course = _SchoolContext.Course.Where(sc => sc.IdCourse == Course.IdCourse);
            if (course.Count() == 0)
            {
                return new JsonResult("The id provided does not exist in the database, please check.");
            }
            else
            {
                _SchoolContext.Course.Update(Course);
                _SchoolContext.SaveChanges();
                return new JsonResult("Saved successfully");
            }
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var course = _SchoolContext.Course.Where(sc => sc.IdCourse == id);
            if (course.Count() == 0)
            {
                return new JsonResult("The id provided does not exist in the database, please check.");
            }
            else
            {
                _SchoolContext.Course.Remove(_SchoolContext.Course.Find(id));
                _SchoolContext.SaveChanges();
                return new JsonResult("Object deleted successfully.");
            }
        }
    }
}