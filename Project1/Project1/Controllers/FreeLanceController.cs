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
            return View();
        }
    }
}