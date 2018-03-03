using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST356_lab3.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

   
        public string FirstName { get; set; }
      
        public string MiddleName { get; set; }
      
        public string LastName { get; set; }
    
        public string EmailAddress { get; set; }

        public int YearsInSchool { get; set; }

        public int GraduationDate { get; set; }

        public int Age { get; set; }
        
        public ICollection<Classes> Classes { get; set; }
    }
}