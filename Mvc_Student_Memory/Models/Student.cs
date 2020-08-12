using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Student_Memory.Models
{
    public class Student
    {
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter Date of Birth")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

      //  [Required(ErrorMessage ="Please Select Gender")]
      // razor view  and enums // damn those exceptions
        [Range(1,3,ErrorMessage = " Please select Gender")]
        public Gender Gender { get; set; }
    }
}