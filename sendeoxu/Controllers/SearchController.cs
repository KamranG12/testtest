using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sendeoxu.Models;

namespace sendeoxu.Controllers
{
    public class SearchController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();
        // GET: Search
        [HttpPost]
        public JsonResult Searchsource(string search)
        {
            var src = db.Sources.Where(s => s.title.Contains(search)).OrderByDescending(o => o.date).Select(b => new { sourceid = b.id, sourcetitle = b.title }).Take(10).ToList();
            return Json(src,JsonRequestBehavior.AllowGet);
        }
    }
}