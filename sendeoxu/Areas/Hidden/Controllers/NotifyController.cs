using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sendeoxu.Models;
using System.Net;
using System.Data.Entity;
using System.Web.Helpers;

namespace sendeoxu.Areas.Hidden.Controllers
{
    public class NotifyController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();
        // GET: Hidden/Notify
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                var say = 0;
            ViewBag.x = db.Sources.Where(s => s.allow == false).ToList();
            foreach (Source sources in ViewBag.x)
            {
                say++;
            }
            Session["new_source"] = say;
            return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Source source = db.Sources.Find(id);
            if (source == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                ViewBag.user_id = new SelectList(db.Users, "id", "fullname", source.user_id);
            return View(source);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/Sources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,text,date,read_count,user_id,kateqoriya_id,allow")] Source source)
        {
            if (ModelState.IsValid)
            {
                db.Entry(source).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname", source.user_id);
            return View(source);
        }

        // GET: Hidden/Sources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Source source = db.Sources.Find(id);
            if (source == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(source);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/Sources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Source source = db.Sources.Find(id);
            db.Sources.Remove(source);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}