using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST356_lab3.ViewModel
{
    public class ViewClassesModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "CRN")]
        public string CRN { get; set; }

        public int UserId { get; set; }
    }
}