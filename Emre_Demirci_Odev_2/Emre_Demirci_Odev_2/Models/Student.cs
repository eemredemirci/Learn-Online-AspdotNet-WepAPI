using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emre_Demirci_Odev_2.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
