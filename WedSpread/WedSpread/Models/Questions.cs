using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WedSpread.Models
{
    [Table("Questions")]
    public class Questions
    {
        [Key]
        public int? QuestionID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        [ForeignKey("Freelancers")]
        public int? FreelancerID { get; set; }

        [ForeignKey("Users")]
        public int? UserID { get; set; }
    }
}