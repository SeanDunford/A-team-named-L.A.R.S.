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
    public class CommentController : Controller
    {

        private BayHelperEntities db = new BayHelperEntities();

        //
        // GET: /Comment/
        [Authorize]
        public ViewResult Index()
        {
            var comments = db.Comments.Include(c => c.Event).Include(c => c.User);
            return View(comments.ToList());
        }

        //
        // GET: /Comment/Details/5
      [Authorize]
        public ViewResult Details(int id)
        {
            Comment comment = db.Comments.Find(id);
            return View(comment);
        }

        //
        // GET: /Comment/Create
                [Authorize]
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName");
            return View();
        } 

        //
        // POST: /Comment/Create
                [Authorize]
        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", comment.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", comment.UserID);
            return View(comment);
        }
        
        //
        // GET: /Comment/Edit/5
         [Authorize]
        public ActionResult Edit(int id)
        {
            Comment comment = db.Comments.Find(id);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", comment.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", comment.UserID);
            return View(comment);
        }

        //
        // POST: /Comment/Edit/5
                [Authorize]
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Title", comment.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "LastName", comment.UserID);
            return View(comment);
        }

        //
        // GET: /Comment/Delete/5
         [Authorize]
        public ActionResult Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5
                [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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