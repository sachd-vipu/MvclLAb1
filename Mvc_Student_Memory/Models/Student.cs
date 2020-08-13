using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Student_Memory.Models
{
    public class Student : IValidatableObject
    {
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }


        [Required(ErrorMessage ="Please enter Date of Birth")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

      //  [Required(ErrorMessage ="Please Select Gender")]
      // razor view  and enums // damn those exceptions
        [Range(1,3,ErrorMessage = " Please select Gender")]
        public Gender Gender { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DateOfBirth >= DateTime.Now)
            {
                yield return new ValidationResult("Date of Birth cannot be in future", new[] { nameof(DateOfBirth)});
            }
        }
    }
}