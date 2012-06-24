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
    public class FinanceDonationController : Controller
    {
        private BayHelperEntities db = new BayHelperEntities();

        //
        // GET: /FinanceDonation/
                [Authorize]
        public ViewResult Index()
        {
            var financedonations = db.FinanceDonations.Include(f => f.Event).Include(f => f.User);
            return View(financedonations.ToList());
        }

        //
        // GET: /FinanceDonation/Details/5
                [Authorize]
        public ViewResult Details(int id)
        {
            FinanceDonation financedonation = db.FinanceDonations.Find(id);
            return View(financedonation);
        }

        //
        // GET: /FinanceDonation/Create
                [Authorize]
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName");
            return View();
        } 

        //
        // POST: /FinanceDonation/Create
                [Authorize]
        [HttpPost]
        public ActionResult Create(FinanceDonation financedonation)
        {
            if (ModelState.IsValid)
            {
                db.FinanceDonations.Add(financedonation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", financedonation.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", financedonation.UserID);
            return View(financedonation);
        }
        
        //
        // GET: /FinanceDonation/Edit/5
         [Authorize]
        public ActionResult Edit(int id)
        {
            FinanceDonation financedonation = db.FinanceDonations.Find(id);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", financedonation.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", financedonation.UserID);
            return View(financedonation);
        }

        //
        // POST: /FinanceDonation/Edit/5
                [Authorize]
        [HttpPost]
        public ActionResult Edit(FinanceDonation financedonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financedonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", financedonation.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", financedonation.UserID);
            return View(financedonation);
        }

        //
        // GET: /FinanceDonation/Delete/5
         [Authorize]
        public ActionResult Delete(int id)
        {
            FinanceDonation financedonation = db.FinanceDonations.Find(id);
            return View(financedonation);
        }

        //
        // POST: /FinanceDonation/Delete/5
                [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            FinanceDonation financedonation = db.FinanceDonations.Find(id);
            db.FinanceDonations.Remove(financedonation);
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