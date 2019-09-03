using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeNotebook
{
    public class ValidationChecks
    {
        public static ValidationResult CheckAge(int yearOfBirth)
        {
            int yearsPassed = DateTime.Now.Year - yearOfBirth;
            return yearsPassed >=14 && yearsPassed <= 100 ?
                ValidationResult.Success : new ValidationResult("Valid age range 14-100 years");

        }
        public static ValidationResult CheckPhone(string phone)
        {
            return Regex.Match(phone, @"^\d[\d\ -]{4,12}\d$").Success ?
                ValidationResult.Success : new ValidationResult("Valid phone contains only numbers, the characters \" \" and \"-\", the length of the number is 6-14");

        }
    }
}