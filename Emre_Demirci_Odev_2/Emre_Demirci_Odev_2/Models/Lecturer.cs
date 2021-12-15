using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emre_Demirci_Odev_2.Models
{
    public class Lecturer
    {
        public Lecturer()
        {
            Courses = new HashSet<Course>();
        }
        public int LecturerID { get; set; }
        public string LecturerName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
