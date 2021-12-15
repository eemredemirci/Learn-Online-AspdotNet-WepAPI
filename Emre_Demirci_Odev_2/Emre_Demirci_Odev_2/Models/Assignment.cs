using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Emre_Demirci_Odev_2.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        [Required(ErrorMessage = "Ödev adı boş geçilemez.")]
        public string AssignmentName { get; set; }
        public int CourseID { get; set; }
        [StringLength(maximumLength: 100)]
        public string AssignmentDescription { get; set; }
        public DateTime AssignmentDeadline { get; set; }
        public Course Courses { get; set; }
    }
}
