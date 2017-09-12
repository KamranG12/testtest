﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sendeoxu.Models;

namespace sendeoxu.Areas.Hidden.Controllers
{
    public class SourcesController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();

        // GET: Hidden/Sources
        public ActionResult Index()
        {
            var sources = db.Sources.Include(s => s.User);
            var say = 0;
            ViewBag.x = db.Sources.Where(s => s.allow == false).ToList();
            foreach (Source source in ViewBag.x)
            {
                say++;
            }
            Session["new_source"] = say;
            return View(sources.ToList());
        }

        // GET: Hidden/Sources/Details/5
        public ActionResult Details(int? id)
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
            return View(source);
        }

        // GET: Hidden/Sources/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname");
            return View();
        }

        // POST: Hidden/Sources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,text,date,read_count,user_id,kateqoriya_id,allow")] Source source)
        {
            if (ModelState.IsValid)
            {
                db.Sources.Add(source);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Users, "id", "fullname", source.user_id);
            return View(source);
        }

        // GET: Hidden/Sources/Edit/5
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
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname", source.user_id);
            return View(source);
        }

        // POST: Hidden/Sources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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
            return View(source);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
