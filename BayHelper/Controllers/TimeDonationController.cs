using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BayHelper.Com.Models;

namespace BayHelper.Com.Controllers
{ 
    public class TimeDonationController : Controller
    {
        private BayHelperEntities db = new BayHelperEntities();

        //
        // GET: /TimeDonation/
          [Authorize]
        public ViewResult Index()
        {
            var timedonations = db.TimeDonations.Include(t => t.Task).Include(t => t.User);
            return View(timedonations.ToList());
        }

        //
        // GET: /TimeDonation/Details/5
          [Authorize]
        public ViewResult Details(int id)
        {
            TimeDonation timedonation = db.TimeDonations.Find(id);
            return View(timedonation);
        }

        //
        // GET: /TimeDonation/Create
          [Authorize]
        public ActionResult Create()
        {
            ViewBag.TaskID = new SelectList(db.Tasks, "TaskID", "Title");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName");
            return View();
        } 

        //
        // POST: /TimeDonation/Create
          [Authorize]
        [HttpPost]
        public ActionResult Create(TimeDonation timedonation)
        {
            if (ModelState.IsValid)
            {
                db.TimeDonations.Add(timedonation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.TaskID = new SelectList(db.Tasks, "TaskID", "Title", timedonation.TaskID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", timedonation.UserID);
            return View(timedonation);
        }
        
        //
        // GET: /TimeDonation/Edit/5
   [Authorize]
        public ActionResult Edit(int id)
        {
            TimeDonation timedonation = db.TimeDonations.Find(id);
            ViewBag.TaskID = new SelectList(db.Tasks, "TaskID", "Title", timedonation.TaskID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", timedonation.UserID);
            return View(timedonation);
        }

        //
        // POST: /TimeDonation/Edit/5
          [Authorize]
        [HttpPost]
        public ActionResult Edit(TimeDonation timedonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timedonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskID = new SelectList(db.Tasks, "TaskID", "Title", timedonation.TaskID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", timedonation.UserID);
            return View(timedonation);
        }

        //
        // GET: /TimeDonation/Delete/5
   [Authorize]
        public ActionResult Delete(int id)
        {
            TimeDonation timedonation = db.TimeDonations.Find(id);
            return View(timedonation);
        }

        //
        // POST: /TimeDonation/Delete/5
          [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            TimeDonation timedonation = db.TimeDonations.Find(id);
            db.TimeDonations.Remove(timedonation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}