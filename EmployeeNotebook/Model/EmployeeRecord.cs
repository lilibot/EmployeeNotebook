using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeNotebook
{
    public class EmployeeRecord
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter the name")]
        [RegularExpression(@"^[A-Za-zА-Яа-я\s]+", ErrorMessage = "Valid name contains only letters and spaces")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the surname")]
        [RegularExpression(@"^[A-Za-zА-Яа-я\s]+", ErrorMessage = "Valid surname contains only letters and spaces")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter the year of birth")]
        [CustomValidation(typeof(ValidationChecks), "CheckAge")]
        public int YearOfBirth { get; set; }
        [Required(ErrorMessage = "Please enter the phone")]
        [CustomValidation(typeof(ValidationChecks), "CheckPhone")]
        public string Phone { get; set; }
    }
}