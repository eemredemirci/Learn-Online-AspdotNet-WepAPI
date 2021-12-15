using Emre_Demirci_Odev_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emre_Demirci_Odev_2.Controller
{
    [Route("api/[controller]/{name}")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        LEARNONLINEDbContext dbContext = new LEARNONLINEDbContext();

        // Öğrencinin Kurslarını listele
        public IActionResult GetStudentCourse(string name)
        {
            Student student = dbContext.Students.SingleOrDefault(s => s.StudentName == name);

            if (student == null)
            {
                return NoContent();
            }

            // Gelen Öğrenci adından ID'ye göre öğrenci derslerini listele :(
            var filtered = dbContext.Students.Where(s => s.StudentID == student.StudentID)
                .Include(student => student.Courses)
                .ToList();
            return Ok(filtered);
        }

        // Öğrencinin Kurs Ödevlerini listele

        [Route("{courseName}")]
        public IActionResult GetStudentAssignment(string courseName)
        {
            Course course = dbContext.Courses.SingleOrDefault(course => course.CourseName == courseName);
            List<Assignment> assignments = dbContext.Assignments.Where(assignments => assignments.CourseID == course.CourseID).ToList();
            if(assignments==null)
            {
                return NoContent();
            }
            return Ok(assignments);

        }
    }
}
