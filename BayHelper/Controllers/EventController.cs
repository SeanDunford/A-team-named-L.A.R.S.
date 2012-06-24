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
        [Authorize]
        public ViewResult Details(int id)
        {
            Event e = db.Events.Find(id);
            return View(e);
        }

        [Authorize]
        public ViewResult MyEvents()
        {
            var events = db.Events.Where(e => e.Creator == WebProfile.Current.UserId);
            return View(events);
        }

        [Authorize]
        public ViewResult InvolvedEvents()
        {
            var finance = db.FinanceDonations.Where(f => f.UserID == WebProfile.Current.UserId && DateTime.Now < f.Event.DueDate).Select(e => e.EventID).ToList();
            var resource = db.ResourceDonations.Where(f => f.UserID == WebProfile.Current.UserId && DateTime.Now < f.Event.DueDate).Select(e => e.EventID).ToList();
            var time = db.TimeDonations.Where(f => f.UserID == WebProfile.Current.UserId && DateTime.Now < f.Event.DueDate).Select(e => e.EventID).ToList();
            var events = db.Events.Where(e => finance.Contains(e.EventID) || resource.Contains(e.EventID) || time.Contains(e.EventID));
            return View(events);
        }

        //
        // GET: /Event/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress1");
            ViewBag.Creator = new SelectList(db.Users, "UserID", "LastName");
            var e = new Event
            {
                Address = new Address()
            };
            return View(e);
        }

        //
        // POST: /Event/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Event e)
        {
            if (ModelState.IsValid)
            {
                e.Creator = WebProfile.Current.UserId;
                db.Events.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        //
        // GET: /Event/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Event e = db.Events.Find(id);
            if (e.Creator == WebProfile.Current.UserId)
            {
                return View(e);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Event/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Event e)
        {
            if (ModelState.IsValid)
            {
                if (e.Creator == WebProfile.Current.UserId)
                {
                    db.Entry(e).State = EntityState.Modified;
                    db.SaveChanges(); 
                }
                return RedirectToAction("Index");
            }
            return View(e);
        }

        //
        // GET: /Event/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Event e = db.Events.Find(id);
            if (e.Creator == WebProfile.Current.UserId)
            {
                return View(e);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Event/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event e = db.Events.Find(id);
            if (e.Creator == WebProfile.Current.UserId)
            {
                db.Events.Remove(e);
                db.SaveChanges(); 
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}