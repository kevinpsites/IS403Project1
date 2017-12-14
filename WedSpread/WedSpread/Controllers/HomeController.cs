using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WedSpread.Models;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private IS403Project2Context db = new IS403Project2Context();

        public User myUser = new WedSpread.Models.User();

        

        public User GetUsers()
        {

            if (User.Identity.IsAuthenticated)
            {
                string myEmail = User.Identity.Name;

                myUser = db.Users.SqlQuery(
                            "SELECT * " +
                            "From Users " +
                            "where Users.UserEmail = '" + myEmail + "'"
                            ).FirstOrDefault();

                if (myUser == null)
                {
                    myUser.UserID = 0;
                    return myUser;
                }
                else
                {
                    return myUser;
                }

            }
            else
            {
                myUser.UserID = 0;

                return myUser;
            }
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                myUser = GetUsers();
                WedSpread.Controllers.HelperController.SetRole(myUser);
                WedSpread.Controllers.HelperController.SetUser(myUser);
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}