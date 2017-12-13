using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WedSpread.Models
{
    [Table("Freelancers")]
    public class Freelancers
    {
        [Key]
        public int? FreelancerID { get; set; }
        public string FreelancerName { get; set; }
        public string FreelancerEmail { get; set; }
        public string FreelancerWebsite { get; set; }
        public string FreelancePicture { get; set; }

        [ForeignKey("Types")]
        public int? TypeID { get; set; }

        [ForeignKey("Users")]
        public int? UserID { get; set; }
    }
}