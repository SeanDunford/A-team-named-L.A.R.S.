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

        public ViewResult Index()
        {
            var timedonations = db.TimeDonations.Include(t => t.Event).Include(t => t.User);
            return View(timedonations.ToList());
        }

        //
        // GET: /TimeDonation/Details/5

        public ViewResult Details(int id)
        {
            TimeDonation timedonation = db.TimeDonations.Find(id);
            return View(timedonation);
        }

        //
        // GET: /TimeDonation/Create

        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName");
            return View();
        } 

        //
        // POST: /TimeDonation/Create

        [HttpPost]
        public ActionResult Create(TimeDonation timedonation)
        {
            if (ModelState.IsValid)
            {
                db.TimeDonations.Add(timedonation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", timedonation.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", timedonation.UserID);
            return View(timedonation);
        }
        
        //
        // GET: /TimeDonation/Edit/5
 
        public ActionResult Edit(int id)
        {
            TimeDonation timedonation = db.TimeDonations.Find(id);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", timedonation.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", timedonation.UserID);
            return View(timedonation);
        }

        //
        // POST: /TimeDonation/Edit/5

        [HttpPost]
        public ActionResult Edit(TimeDonation timedonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timedonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", timedonation.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", timedonation.UserID);
            return View(timedonation);
        }

        //
        // GET: /TimeDonation/Delete/5
 
        public ActionResult Delete(int id)
        {
            TimeDonation timedonation = db.TimeDonations.Find(id);
            return View(timedonation);
        }

        //
        // POST: /TimeDonation/Delete/5

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