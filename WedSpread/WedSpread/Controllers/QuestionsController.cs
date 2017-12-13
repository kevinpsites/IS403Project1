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
            IEnumerable<Question> FreeQuestions = db.Questions.SqlQuery("SELECT * " +
                "FROM Questions" +
                "WHERE FreelancerID = '"  + id + "'").AsEnumerable();
            var questions = db.Questions.Include(q => q.Freelancer).Include(q => q.User);
            return View(questions.ToList());
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
        public ActionResult Create([Bind(Include = "QuestionID,Question1,Answer,FreelancerID,UserID")] Question question)
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
        public ActionResult Edit([Bind(Include = "QuestionID,Question1,Answer,FreelancerID,UserID")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FreelancerID = new SelectList(db.Freelancers, "FreelancerID", "FreelancerName", question.FreelancerID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserEmail", question.UserID);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
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
