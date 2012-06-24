using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BayHelper.Com.Models;

namespace BayHelper.Com.Controllers
{
    public class HomeController : Controller
    {
        BayHelperEntities db = new BayHelperEntities();

        public ActionResult Index()
        {
            var tst = db.Events.Where(e => e.DueDate > DateTime.Now).OrderByDescending(e => e.EventID).Take(5).ToList();
            ViewBag.Latest = db.Events.Where(e => e.DueDate > DateTime.Now).OrderByDescending(e => e.EventID).Take(5).ToList();
            ViewBag.Popular = db.Events.Where(e => e.DueDate > DateTime.Now).OrderByDescending(e => e.TimeDonations.Count() + e.ResourceDonations.Count() + e.FinanceDonations.Count()).Take(5).ToList();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult DiscoverTampaBay()
        {
            return View();
        }
    }
}
