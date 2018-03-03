using System;
using System.ComponentModel.DataAnnotations;


namespace CST356_lab3.Data.Entities
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }

        public string ClassName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string CRN { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}