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
            return RedirectToAction("Bio");
        }

        public ActionResult Molly()
        {
            return RedirectToAction("Bio");
        }
    }
}