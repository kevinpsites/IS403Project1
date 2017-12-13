using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    //questions class
    public class Question
    {
        //attributes for the class with gets and sets
        public  int iNumber { get; set; }
        public  string sQuestion { get; set; }
        public  string sName { get; set; }
        public  string dDate { get; set; }
        public  string sAnswer { get; set; }

        //constructor for the class
        public Question(int iNum)
        {
            iNumber = iNum;
        }
    }

    
}