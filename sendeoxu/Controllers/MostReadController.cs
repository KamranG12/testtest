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
            ViewBag.category = db.Categories.ToList();
            return View();
        }
    }
}