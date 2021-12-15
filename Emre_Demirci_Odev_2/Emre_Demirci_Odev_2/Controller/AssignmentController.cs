using Emre_Demirci_Odev_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emre_Demirci_Odev_2.Controller
{
    [Route("api/{name}/Course/{courseName}/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        LEARNONLINEDbContext dbContext = new LEARNONLINEDbContext();

        [Route("New")]
        [HttpPost]
        public IActionResult AddAssignment(string courseName,Assignment assignment)
        {
            Course course = dbContext.Courses.SingleOrDefault(course => course.CourseName == courseName);
            if (course == null)
            {
                return NoContent();
            }
            assignment.CourseID = course.CourseID;
            dbContext.Assignments.Add(assignment);
            dbContext.SaveChanges();
            return Ok(course.CourseName + "eklendi.");
        }
    }
}
