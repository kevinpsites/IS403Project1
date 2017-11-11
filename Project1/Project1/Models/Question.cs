using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Question
    {
        public  int iNumber;
        public  string sQuestion;
        public  string sName;
        public  string dDate;
        public  string sAnswer;

        public Question(int iNum)
        {
            iNumber = iNum;
        }
    }

    
}