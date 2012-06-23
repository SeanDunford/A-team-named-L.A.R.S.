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
    public class ResourceDonationController : Controller
    {
        private BayHelperEntities db = new BayHelperEntities();

        //
        // GET: /ResourceDonation/
          [Authorize]
        public ViewResult Index()
        {
            var resourcedonations = db.ResourceDonations.Include(r => r.Resource).Include(r => r.User);
            return View(resourcedonations.ToList());
        }

        //
        // GET: /ResourceDonation/Details/5
          [Authorize]
        public ViewResult Details(int id)
        {
            ResourceDonation resourcedonation = db.ResourceDonations.Find(id);
            return View(resourcedonation);
        }

        //
        // GET: /ResourceDonation/Create
          [Authorize]
        public ActionResult Create()
        {
            ViewBag.ResorceID = new SelectList(db.Resources, "ResourceID", "Description");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName");
            return View();
        } 

        //
        // POST: /ResourceDonation/Create
          [Authorize]
        [HttpPost]
        public ActionResult Create(ResourceDonation resourcedonation)
        {
            if (ModelState.IsValid)
            {
                db.ResourceDonations.Add(resourcedonation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ResorceID = new SelectList(db.Resources, "ResourceID", "Description", resourcedonation.ResorceID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", resourcedonation.UserID);
            return View(resourcedonation);
        }
        
        //
        // GET: /ResourceDonation/Edit/5
   [Authorize]
        public ActionResult Edit(int id)
        {
            ResourceDonation resourcedonation = db.ResourceDonations.Find(id);
            ViewBag.ResorceID = new SelectList(db.Resources, "ResourceID", "Description", resourcedonation.ResorceID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", resourcedonation.UserID);
            return View(resourcedonation);
        }

        //
        // POST: /ResourceDonation/Edit/5
          [Authorize]
        [HttpPost]
        public ActionResult Edit(ResourceDonation resourcedonation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourcedonation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResorceID = new SelectList(db.Resources, "ResourceID", "Description", resourcedonation.ResorceID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", resourcedonation.UserID);
            return View(resourcedonation);
        }

        //
        // GET: /ResourceDonation/Delete/5
   [Authorize]
        public ActionResult Delete(int id)
        {
            ResourceDonation resourcedonation = db.ResourceDonations.Find(id);
            return View(resourcedonation);
        }

        //
        // POST: /ResourceDonation/Delete/5
          [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ResourceDonation resourcedonation = db.ResourceDonations.Find(id);
            db.ResourceDonations.Remove(resourcedonation);
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