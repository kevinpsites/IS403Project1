using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Question
    {
        public  int iNumber { get; set; }
        public  string sQuestion { get; set; }
        public  string sName { get; set; }
        public  string dDate { get; set; }
        public  string sAnswer { get; set; }

        public Question(int iNum)
        {
            iNumber = iNum;
        }
    }

    
}