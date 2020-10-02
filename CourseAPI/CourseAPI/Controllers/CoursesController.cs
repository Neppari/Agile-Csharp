using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private static List<Course> Courses = new List<Course>
        {
            new Course{Id = 1, Name = "Kurssi1", Credits = 5},
            new Course{Id = 2, Name = "Kurssi2", Credits = 3},
            new Course{Id = 3, Name = "Kurssi3", Credits = 2}
        };

        [HttpPut("{id}")]
        public List<Course> Put(int id, [FromBody] Course course)
        {
            var updatedCourseList = Courses.Select(c => c.Id != id ? c : course).ToList();
            return updatedCourseList;
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Course newCourse)
        {
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Course course = Courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
                return NotFound();

            Courses = Courses.Where(c => c.Id != id).ToList();
            return Ok(course);
        }
    }
}
