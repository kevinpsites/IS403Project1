using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedSpread.Models;

namespace WedSpread.Controllers
{
    public class HelperController : Controller
    {
        private IS403Project2Context db = new IS403Project2Context();
        
        public static  int Role;

        public static int myUser;

        public static int SetRole(User user)
        {   
            Role = user.RoleID;

            return Role;
        }

        public static int GetRole()
        {
            return Role;
        }

        public static int SetUser(User user)
        {
            foreach (var item in user.Freelancers)
            {
                myUser = item.FreelancerID;
            }
            

            return myUser;
        }

        public static int GetUser()
        {
            return myUser;
        }

    }
}