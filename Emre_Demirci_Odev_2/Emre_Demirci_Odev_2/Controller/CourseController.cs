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
    [Route("api/{name}/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        LEARNONLINEDbContext dbContext = new LEARNONLINEDbContext();

        // Öğretmen Kurslarını listele
        public IActionResult GetLecturerCourses(string name)
        {
            Lecturer lecturer = dbContext.Lecturers.SingleOrDefault(lecturer => lecturer.LecturerName == name);

            var filtered = dbContext.Lecturers.Where(c => c.LecturerID == lecturer.LecturerID)
                .Include(lecturer => lecturer.Courses)
                .ToList();
            return Ok(filtered);
        }

        // Kurstaki Öğrencileri listele Many to Many

        [HttpGet("{courseName}")]
        public IActionResult GetCourseByName(string courseName)
        {
            Course course = dbContext.Courses.SingleOrDefault(course => course.CourseName == courseName);

            if (course == null)
            {
                return NoContent();
            }
            
            // Gelen kurs adından ID'ye göre öğrenci isimlerini listele :(
            var filtered = dbContext.Courses.Where(c => c.CourseID == course.CourseID)
                .Include(student => student.Students)
                .ToList();
            return Ok(filtered);
        }

        // Yeni kurs ekle
        [Route("New")]
        [HttpPost]
        public IActionResult AddCourse(string name, Course course)
        {
            // Öğretmen kontrolü
            Lecturer lecturers = dbContext.Lecturers.SingleOrDefault(lecturers => lecturers.LecturerName == name);
            if (lecturers == null)
            {
                return NotFound("Lecturer '" + name + "' not found!");
            }

            // Database'e MANY TO MANY kurs ekle :(
            dbContext.AddRange(
                new Course
                {
                    CourseName = course.CourseName,
                    CourseDuration = course.CourseDuration,
                    Lecturers = new List<Lecturer> { lecturers }
                }
                //,
                //new Lecturer
                //{

                //}
                );
            dbContext.SaveChanges();

            return Ok();
        }

    }
}
