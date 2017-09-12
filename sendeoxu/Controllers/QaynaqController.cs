using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using sendeoxu.Models;
using System.Web.Helpers;

namespace sendeoxu.Controllers
{
    public class QaynaqController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();
        // GET: Qaynaq
        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddSource(Source source)
        {

            if (source.title != null && source.text != null)
            {
                source.read_count = 0;
                source.allow = false;
                db.Sources.Add(source);
                RelCatAndSor rel = new RelCatAndSor();
                rel.kateqoriya_id = source.kateqoriya_id;
                rel.topic_id = source.id;
                db.RelCatAndSors.Add(rel);
                db.SaveChanges();
                Session["source"] = "Təşəkkürlər! Qaynaq təsdiqləndikdən sonra səhifəyə əlavə ediləcəkdir.";
                return RedirectToAction("index", "qaynaq");
            }
            else
            {
                Session["source"] = "Zəhmət olmasa boşluq buraxmayın";
                return RedirectToAction("index","qaynaq");
            }
            
        }
    }
}