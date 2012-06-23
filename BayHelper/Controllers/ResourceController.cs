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
    public class ResourceController : Controller
    {
        private BayHelperEntities db = new BayHelperEntities();

        //
        // GET: /Resource/

        public ViewResult Index()
        {
            var resources = db.Resources.Include(r => r.Event);
            return View(resources.ToList());
        }

        //
        // GET: /Resource/Details/5

        public ViewResult Details(int id)
        {
            Resource resource = db.Resources.Find(id);
            return View(resource);
        }

        //
        // GET: /Resource/Create

        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title");
            return View();
        } 

        //
        // POST: /Resource/Create

        [HttpPost]
        public ActionResult Create(Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", resource.EventID);
            return View(resource);
        }
        
        //
        // GET: /Resource/Edit/5
 
        public ActionResult Edit(int id)
        {
            Resource resource = db.Resources.Find(id);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", resource.EventID);
            return View(resource);
        }

        //
        // POST: /Resource/Edit/5

        [HttpPost]
        public ActionResult Edit(Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", resource.EventID);
            return View(resource);
        }

        //
        // GET: /Resource/Delete/5
 
        public ActionResult Delete(int id)
        {
            Resource resource = db.Resources.Find(id);
            return View(resource);
        }

        //
        // POST: /Resource/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
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