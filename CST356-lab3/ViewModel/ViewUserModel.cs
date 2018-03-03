using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST356_lab3.ViewModel
{
    public class ViewUserModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Years in School")]
        public int YearsInSchool { get; set; }

        [Required]
        [Display(Name = "Graduation Date")]
        public int GraduationDate { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }
    }
}