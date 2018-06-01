using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        [Display(Name = "Student ID")]
        [RegularExpression(@"^[0-9-]*$")]
        public string SID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string FirstName { get; set; }
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Intake { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Registration Complete")]
        public DateTime Registration { get; set; }

        public int GoalID { get; set; }
        public int BedaprogramID { get; set; }
        public int AdvisorID { get; set; }
        [Display(Name = "File Location")]
        public int LocationID { get; set; }

        public Goal Goal { get; set; }
        public Bedaprogram Bedaprogram { get; set; }
        public Advisor Advisor { get; set; }
        public Location Location { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
