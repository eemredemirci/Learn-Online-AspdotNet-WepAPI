using Emre_Demirci_Odev_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emre_Demirci_Odev_2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        LEARNONLINEDbContext dbContext = new LEARNONLINEDbContext();

        // Bütün Öğretmenleri listele
        [Route("Lecturers")]
        public IActionResult GetLecturers()
        {
            List<Lecturer> lecturers = dbContext.Lecturers.ToList();
            return Ok(lecturers);
        }

        // Öğretmenin ismi ile Giriş temsili Giriş
        [Route("{name}")]
        public IActionResult SigninLecturer(string name)
        {
            Lecturer lecturers = dbContext.Lecturers.SingleOrDefault(lecturers => lecturers.LecturerName == name);

            if (lecturers == null)
            {
                return NotFound("Lecturer '" + name + "' not found!");
            }
            List<Course> courses = dbContext.Courses.Where(courses => courses.CourseID == lecturers.LecturerID).ToList();
            // Hoşgeldiniz Mesajı
            return Ok("Hoş Geldiniz " + lecturers.LecturerName + " " + courses);
        }

    }
}
