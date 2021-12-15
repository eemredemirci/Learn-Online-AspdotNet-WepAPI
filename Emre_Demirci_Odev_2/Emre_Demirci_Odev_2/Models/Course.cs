using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Emre_Demirci_Odev_2.Models
{
    public class Course
    {
        public Course()
        {
            Lecturers = new HashSet<Lecturer>();
            Students = new HashSet<Student>();
            Assignments = new HashSet<Assignment>();
        }
        [Key]
        public int CourseID { get; set; }
        [Required]
        public string CourseName { get; set; }
        public decimal CourseDuration { get; set; }

        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
