using sendeoxu.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sendeoxu.Controllers
{
    public class ReadController : Controller
    {
        // GET: Read
        private FirstProjectEntities db = new FirstProjectEntities();
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                var idcat = db.Sources.FirstOrDefault(i => i.id == id);
                Session["source_id"] = id;
                ViewBag.category = db.Categories.Where(d => d.id == idcat.kateqoriya_id).First();
                ViewBag.username = db.Users.Where(u => u.id == idcat.user_id).First();
                ViewBag.qaynaq = idcat;
                ViewBag.like = db.Reviews.Where(r => r.liked == 1 && r.topic_id == idcat.id).Count();
                ViewBag.dislike = db.Reviews.Where(r => r.dislike == 1 && r.topic_id == idcat.id).Count();
                this.artir(idcat);
                return View();
            }
            else
            {
                return HttpNotFound();
            }

        }

        private void artir(Source src)
        {

            src.read_count = src.read_count + 1;
            db.SaveChanges();
        }

        [HttpGet]
        public JsonResult Like()
        {
            Review review = new Review();
            review.user_id = Convert.ToInt32(Session["user_id"].ToString());
            review.topic_id = Convert.ToInt32(Session["source_id"].ToString());
            Review rv = db.Reviews.FirstOrDefault(r => r.topic_id == review.topic_id && r.user_id == review.user_id);
            var response = 0;
            if (rv == null)
            {
                review.dislike = 0;
                review.liked = 1;
                db.Reviews.Add(review);
                response = 1;
            }
            else if (rv.liked==1)
            {
                rv.liked = 0;
                response = 2;
            }
            else if(rv.dislike==1)
            {
                rv.dislike = 0;
                rv.liked = 1;
                response = 3;
            }
            else
            {
                rv.liked = 1;
                response = 1;
            }

            db.SaveChanges();
            int like_count= db.Reviews.Where(r => r.liked == 1 && r.topic_id == review.topic_id).Count();
            int dislike_count= db.Reviews.Where(r => r.dislike == 1 && r.topic_id == review.topic_id).Count();
            int[] view = new int[] { response, like_count, dislike_count };
            
            return Json(view, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Dislike()
        {
            Review review = new Review();
            review.user_id = Convert.ToInt32(Session["user_id"].ToString());
            review.topic_id = Convert.ToInt32(Session["source_id"].ToString());
            Review rv = db.Reviews.FirstOrDefault(r => r.topic_id == review.topic_id && r.user_id == review.user_id);
            var response = 0;
            if (rv == null)
            {
                review.dislike = 1;
                review.liked = 0;
                db.Reviews.Add(review);
                response = 1;
            }
            else if (rv.dislike == 1)
            {
                rv.dislike = 0;
                response = 2;
            }
            else if (rv.liked == 1)
            {
                rv.dislike = 1;
                rv.liked = 0;
                response = 3;
            }
            else
            {
                rv.dislike = 1;
                response = 1;
            }
            db.SaveChanges();
            int like_count = db.Reviews.Where(r => r.liked == 1 && r.topic_id == review.topic_id).Count();
            int dislike_count = db.Reviews.Where(r => r.dislike == 1 && r.topic_id == review.topic_id).Count();
            int[] view = new int[] { response, like_count, dislike_count };

            return Json(view, JsonRequestBehavior.AllowGet);
        }
    }
}