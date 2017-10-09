using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sendeoxu.Models;
using PagedList;
using PagedList.Mvc;

namespace sendeoxu.Controllers
{
    public class HomeController : Controller
    {
        FirstProjectEntities db = new FirstProjectEntities();
        public ActionResult Index(int? page,int? id)
        {
            ViewBag.category = db.Categories.ToList();
            ViewBag.catname = db.Categories.ToList();
            ViewBag.user_reytinq = db.Users.OrderByDescending(u => u.reytinq).Take(10);
            if (id != null)
            {
                return View(db.Sources.Where(s => s.allow == true&&s.kateqoriya_id==id).OrderByDescending(o => o.date).ToList().ToPagedList(page ?? 1, 5));
            }
            else
            {
                return View(db.Sources.Where(s => s.allow == true).OrderByDescending(o => o.date).ToList().ToPagedList(page ?? 1, 5));
            }
        }
    }
}