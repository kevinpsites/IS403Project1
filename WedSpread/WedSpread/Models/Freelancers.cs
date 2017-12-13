using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedSpread.Models
{
    public class Freelancers
    {
        public int FreelancerID { get; set; }
        public string FreelancerName { get; set; }
        public string FreelancerEmail { get; set; }
        public string FreelancerWebsite { get; set; }
        public string FreelancePicture { get; set; }
        public int? TypeID { get; set; }
        public int? UserID { get; set; }
    }
}