using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class FreeLanceController : Controller
    {
        public static Question q1 = new Question(1);
        public static Question q2 = new Question(2);
        public static Question q3 = new Question(3);
        public static Dictionary<int, Question> qs = new Dictionary<int, Question>();
      

        // GET: FreeLance
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: FreelancerBio
        public ActionResult Bio()
        {
            q1.sQuestion = "What type of music do you guys play?";
            q1.sName = "Greg Anderson";
            q1.dDate = "11/5/2017";
            q1.sAnswer = "We play folk music and bluegrass band music.";

            q2.sQuestion = "Do you do drone videography?";
            q2.sName = "Harley Dent";
            q2.dDate = "10/27/2017";
            q2.sAnswer = "Yes that is one of our specialites.";

            q3.sQuestion = "Do you take family pictures?";
            q3.sName = "Taylor Wells";
            q3.dDate = "10/20/2017";
            q3.sAnswer = "Absolutely!";

            qs.Add(q1.iNumber, q1);
            qs.Add(q2.iNumber, q2);
            qs.Add(q3.iNumber, q3);

            ViewBag.name = TempData["name"];
            ViewBag.picture = TempData["picture"];
            ViewBag.bio = TempData["bio"];
            ViewBag.portfolio = TempData["portfolio"];
            ViewBag.faqs = TempData["faqs"];

            return View(qs);
        }

        public ActionResult Elevated()
        {
            TempData["name"] = "Elevated-Films";
            TempData["picture"] = "Elivated Films full white.jpg";
            TempData["bio"] = "A simple, professional, and affordable videography company for all of your events. " +
                        "We offer a comprehensive experience to capture your moments from every angle. Reaching " +
                        "new heights of event filmography, the sky truly is the limit.";
            TempData["portfolio"] = "http://elevated-films.com";
            TempData["faqs"] = "Elevated-Films";

            return RedirectToAction("Bio");
        }

        public ActionResult Photographer()
        {
            TempData["name"] = "Look It Photography";
            TempData["picture"] = "profile.jpg";
            TempData["bio"] = "I'm a Salt Lake County, Utah-based photographer who loves capturing the small and simple beauties " +
                "of life. I believe that photography has emotion, and a power to capture the goodness of life. " +
                "Photos allow people to experience and reflect on life in ways often overlooked in our rushed world. " +
                "My passion is to capture details and stories through unique and compelling images. " +
                "The world is an amazing place, and my hope is to uplift and enrich the lives of those around me.";
            TempData["portfolio"] = "https://www.lookitphotography.com/";
            TempData["faqs"] = "Look It Photography";

            return RedirectToAction("Bio");
        }

        public ActionResult Molly()
        {
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

            return RedirectToAction("Bio");
        }

        public ActionResult Questions()
        {
            ViewBag.partial = "@Html.Partial("+ "Questions" + ")";
            return PartialView("Questions");
        }
    }
}