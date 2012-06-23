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
    public class EventController : Controller
    {
        private BayHelperEntities db = new BayHelperEntities();

        //
        // GET: /Event/

        public ViewResult Index()
        {
            var events = db.Events.Include(e => e.Address).Include(e => e.User);
            return View(events.ToList());
        }

        //
        // GET: /Event/Details/5

        public ViewResult Details(int id)
        {
            Event event = db.Events.Find(id);
            return View(event);
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress");
            ViewBag.Creator = new SelectList(db.Users, "UserID", "LastName");
            return View();
        } 

        //
        // POST: /Event/Create

        [HttpPost]
        public ActionResult Create(Event event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(event);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", event.AddressID);
            ViewBag.Creator = new SelectList(db.Users, "UserID", "LastName", event.Creator);
            return View(event);
        }
        
        //
        // GET: /Event/Edit/5
 
        public ActionResult Edit(int id)
        {
            Event event = db.Events.Find(id);
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", event.AddressID);
            ViewBag.Creator = new SelectList(db.Users, "UserID", "LastName", event.Creator);
            return View(event);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        public ActionResult Edit(Event event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", event.AddressID);
            ViewBag.Creator = new SelectList(db.Users, "UserID", "LastName", event.Creator);
            return View(event);
        }

        //
        // GET: /Event/Delete/5
 
        public ActionResult Delete(int id)
        {
            Event event = db.Events.Find(id);
            return View(event);
        }

        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Event event = db.Events.Find(id);
            db.Events.Remove(event);
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