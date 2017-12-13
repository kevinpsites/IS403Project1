using WedSpread.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project1.Controllers
{
    public class FreeLanceController : Controller
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
        
       

        // GET: FreeLance
        public ActionResult Index()
        {
            IEnumerable<Freelancer> freelancer = db.Freelancers.ToList();  

            return View(freelancer);
        }

        // GET: FreelancerBio
        public ActionResult Bio(int id)
        {
            Freelancer freelancer = db.Freelancers.Find(id);
            User userID = new WedSpread.Models.User();
            userID = GetUsers();
            freelancer.UserID = userID.UserID;

            return View(freelancer);
        }

        public ActionResult Elevated()
        {
            //adding data to temp data to pass to viewbag
            TempData["name"] = "Elevated-Films";
            TempData["picture"] = "Elivated Films full white.jpg";
            TempData["bio"] = "A simple, professional, and affordable videography company for all of your events. " +
                        "We offer a comprehensive experience to capture your moments from every angle. Reaching " +
                        "new heights of event filmography, the sky truly is the limit.";
            TempData["portfolio"] = "http://elevated-films.com";
            TempData["faqs"] = "Elevated-Films";

            //redirecting to bio method to display
            return RedirectToAction("Bio");
        }

        public ActionResult Photographer()
        {
            //question object with data
            TempData["name"] = "Look It Photography";
            TempData["picture"] = "profile.jpg";
            TempData["bio"] = "I'm a Salt Lake County, Utah-based photographer who loves capturing the small and simple beauties " +
                "of life. I believe that photography has emotion, and a power to capture the goodness of life. " +
                "Photos allow people to experience and reflect on life in ways often overlooked in our rushed world. " +
                "My passion is to capture details and stories through unique and compelling images. " +
                "The world is an amazing place, and my hope is to uplift and enrich the lives of those around me.";
            TempData["portfolio"] = "https://www.lookitphotography.com/";
            TempData["faqs"] = "Look It Photography";

            //redirecting to bio method to display
            return RedirectToAction("Bio");
        }

        public ActionResult Molly()
        {
            //question object with data
            TempData["name"] = "Molly in the Mineshaft";
            TempData["picture"] = "Molly1.jpg";
            TempData["bio"] = "Molly in the Mineshaft was founded in 2014 in Provo, Utah while its members " +
                        "were attending college and performing with other bands. Their purpose is to " +
                        "uplift, entertain, and inspire people of all ages through high-energy, diverse music. " +
                        "The band’s music reveals their wide range of musical influences and features flavors " +
                        "of contemporary folk, bluegrass, blues, jazz, Celtic, and rock. " +
                        "Members of the band have performed throughout North America and Europe, " +
                        "including the United States, Mexico, Croatia, France, Switzerland, and Spain. " +
                        "Their audiences range from Elementary school children to international dignitaries.";
            TempData["portfolio"] = "https://mollyinthemineshaft.com/";
            TempData["faqs"] = "Molly in the Mineshaft";

            //redirecting to bio method to display
            return RedirectToAction("Bio");
        }

        public ActionResult Questions()
        {
            return PartialView("Questions");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostQuestions(FormCollection form)
        {
            Question question = new Question();
            if (ModelState.IsValid)
            {
                int userID = Convert.ToInt16(form["UserID"].ToString());
                question.User = db.Users.Find(userID);

                int freelancerid = Convert.ToInt16(form["FreelancerID"].ToString());
                question.Freelancer = db.Freelancers.Find(freelancerid);

                question.Question1 = form["Question"].ToString();
                
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Bio", new { id = freelancerid });
            }


            return View("Index");
        }
    }
}