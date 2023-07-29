using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HairCut.Models;

namespace HairCut.Controllers
{
    [Authorize]
    public class Working_HoursController : Controller
    {
        private HaircutEntities db = new HaircutEntities();
        public ActionResult Index()
        {
            return View(db.Working_Hours.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Working_Hours working_Hours = db.Working_Hours.Find(id);
            if (working_Hours == null)
            {
                return HttpNotFound();
            }
            return View(working_Hours);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Working_Hours working_Hours)
        {
            if (ModelState.IsValid)
            {
                db.Working_Hours.Add(working_Hours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(working_Hours);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Working_Hours working_Hours = db.Working_Hours.Find(id);
            if (working_Hours == null)
            {
                return HttpNotFound();
            }
            return View(working_Hours);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Working_Hours working_Hours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(working_Hours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(working_Hours);
        }
        public ActionResult Delete(int id)
        {
            Working_Hours working_Hours = db.Working_Hours.Find(id);
            db.Working_Hours.Remove(working_Hours);
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
