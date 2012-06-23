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
    public class MessageController : Controller
    {
        private BayHelperEntities db = new BayHelperEntities();

        //
        // GET: /Message/

        public ViewResult Index()
        {
            var messages = db.Messages.Include(m => m.User).Include(m => m.User1);
            return View(messages.ToList());
        }

        //
        // GET: /Message/Details/5

        public ViewResult Details(int id)
        {
            Message message = db.Messages.Find(id);
            return View(message);
        }

        //
        // GET: /Message/Create

        public ActionResult Create()
        {
            ViewBag.Sender = new SelectList(db.Users, "UserID", "LastName");
            ViewBag.Recepient = new SelectList(db.Users, "UserID", "LastName");
            return View();
        } 

        //
        // POST: /Message/Create

        [HttpPost]
        public ActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.Sender = new SelectList(db.Users, "UserID", "LastName", message.Sender);
            ViewBag.Recepient = new SelectList(db.Users, "UserID", "LastName", message.Recepient);
            return View(message);
        }
        
        //
        // GET: /Message/Edit/5
 
        public ActionResult Edit(int id)
        {
            Message message = db.Messages.Find(id);
            ViewBag.Sender = new SelectList(db.Users, "UserID", "LastName", message.Sender);
            ViewBag.Recepient = new SelectList(db.Users, "UserID", "LastName", message.Recepient);
            return View(message);
        }

        //
        // POST: /Message/Edit/5

        [HttpPost]
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sender = new SelectList(db.Users, "UserID", "LastName", message.Sender);
            ViewBag.Recepient = new SelectList(db.Users, "UserID", "LastName", message.Recepient);
            return View(message);
        }

        //
        // GET: /Message/Delete/5
 
        public ActionResult Delete(int id)
        {
            Message message = db.Messages.Find(id);
            return View(message);
        }

        //
        // POST: /Message/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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