using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class FreeLanceController : Controller
    {
        // GET: FreeLance
        public ActionResult Index()
        {
            return View();
        }

        // GET: FreelancerBio
        public ActionResult Bio()
        {
            ViewBag.name = TempData["name"];
            ViewBag.picture = TempData["picture"];
            ViewBag.bio = TempData["bio"];
            ViewBag.portfolio = TempData["portfolio"];
            ViewBag.faqs = TempData["faqs"];

            return View();
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
    }
}