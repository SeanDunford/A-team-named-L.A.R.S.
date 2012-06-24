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
    public class OrganizationController : Controller
    {
        private BayHelperEntities db = new BayHelperEntities();

        //
        // GET: /Organization/
                [Authorize]
        public ViewResult Index()
        {
            return View(db.Organizations.ToList());
        }

        //
        // GET: /Organization/Details/5
                [Authorize]
        public ViewResult Details(int id)
        {
            Organization organization = db.Organizations.Find(id);
            return View(organization);
        }

        //
        // GET: /Organization/Create
                [Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Organization/Create
                [Authorize]
        [HttpPost]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(organization);
        }
        
        //
        // GET: /Organization/Edit/5
         [Authorize]
        public ActionResult Edit(int id)
        {
            Organization organization = db.Organizations.Find(id);
            return View(organization);
        }

        //
        // POST: /Organization/Edit/5
                [Authorize]
        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        //
        // GET: /Organization/Delete/5
         [Authorize]
        public ActionResult Delete(int id)
        {
            Organization organization = db.Organizations.Find(id);
            return View(organization);
        }

        //
        // POST: /Organization/Delete/5
          [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
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