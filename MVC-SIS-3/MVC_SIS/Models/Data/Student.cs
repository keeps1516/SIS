using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Exercises.Models.Data
{
    public class Student
    {
        
        public int StudentId { get; set; }
        [RequiredNotEmpty(ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }
        [RequiredNotEmpty(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}", ErrorMessage ="You must enter a valid GPA")]
        [Range(0, 4)]
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}