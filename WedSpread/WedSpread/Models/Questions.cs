using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedSpread.Models
{
    public class Questions
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int? FreelancerID { get; set; }
        public int? UserID { get; set; }
    }
}