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
    public class UserController : Controller
    {
        private BayHelperEntities db = new BayHelperEntities();

        //
        // GET: /User/

        public ViewResult Index()
        {
            var users = db.Users.Include(u => u.Address).Include(u => u.Organization);
            return View(users.ToList());
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
        {
            User user = db.Users.Find(id);
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress");
            ViewBag.OrganizationID = new SelectList(db.Organizations, "OrganizationID", "Name");
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", user.AddressID);
            ViewBag.OrganizationID = new SelectList(db.Organizations, "OrganizationID", "Name", user.OrganizationID);
            return View(user);
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", user.AddressID);
            ViewBag.OrganizationID = new SelectList(db.Organizations, "OrganizationID", "Name", user.OrganizationID);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "AddressID", "StreetAddress", user.AddressID);
            ViewBag.OrganizationID = new SelectList(db.Organizations, "OrganizationID", "Name", user.OrganizationID);
            return View(user);
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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