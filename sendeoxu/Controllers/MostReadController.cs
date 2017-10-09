using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sendeoxu.Models;

namespace sendeoxu.Controllers
{
    public class MostReadController : Controller
    {
        // GET: MostRead
        private FirstProjectEntities db = new FirstProjectEntities();
        public ActionResult Index()
        {
            ViewBag.mostread = db.Sources.OrderByDescending(s => s.read_count).Take(10);
            ViewBag.category = db.Categories.ToList();
            ViewBag.catname = db.Categories.ToList();
            ViewBag.user_reytinq = db.Users.OrderByDescending(u => u.reytinq).Take(10);
            return View();
        }
    }
}