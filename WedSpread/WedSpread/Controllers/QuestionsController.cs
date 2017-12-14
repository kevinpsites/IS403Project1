using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WedSpread.Models;

namespace WedSpread.Controllers
{
    public class QuestionsController : Controller
    {
        private IS403Project2Context db = new IS403Project2Context();

        // GET: Questions
        public ActionResult Index(int id)
        {
            IEnumerable<Question> FreeQuestions = db.Database.SqlQuery<Question>("SELECT * " +
                 "FROM Questions " +
                 "WHERE FreelancerID = '" + id + "'").AsEnumerable();

            return View(FreeQuestions);
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.FreelancerID = new SelectList(db.Freelancers, "FreelancerID", "FreelancerName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserEmail");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionID,Question1,Answer,FreelancerID,UserID")] Question question, int fID)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FreelancerID = new SelectList(db.Freelancers, "FreelancerID", "FreelancerName", question.FreelancerID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserEmail", question.UserID);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.FreelancerID = new SelectList(db.Freelancers, "FreelancerID", "FreelancerName", question.FreelancerID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserEmail", question.UserID);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            Question question = new Question();

            if (ModelState.IsValid)
            {
                question.QuestionID = Convert.ToInt16(form["QuestionID"].ToString());
                question.FreelancerID = Convert.ToInt16(form["FreelancerID"].ToString());
                question.UserID = Convert.ToInt16(form["UserID"].ToString());
                question.Answer = form["Answer"].ToString();
             
                db.Database.ExecuteSqlCommand(
                    "Update Questions " +
                    "Set Questions.Answer = '" + question.Answer + "' " +
                    "where Questions.QuestionID = '" + question.QuestionID + "'"
                    );

                db.SaveChanges();
                return RedirectToAction("Index", new { id = question.FreelancerID });
            }
            ViewBag.FreelancerID = new SelectList(db.Freelancers, "FreelancerID", "FreelancerName", question.FreelancerID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserEmail", question.UserID);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id, int fID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int fID)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = fID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
