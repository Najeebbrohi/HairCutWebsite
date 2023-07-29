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
    public class BarbarsController : Controller
    {
        private HaircutEntities db = new HaircutEntities();
        public ActionResult Index()
        {
            return View(db.Barbars.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Barbar barbar)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileNameWithoutExtension(barbar.UserImagePath.FileName);
                var extension = Path.GetExtension(barbar.UserImagePath.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                barbar.ImagePath = "~/Content/uploaded/" + filename;
                filename = Path.Combine(Server.MapPath("~/Content/uploaded/"), filename);
                barbar.UserImagePath.SaveAs(filename);

                db.Barbars.Add(barbar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barbar);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barbar barbar = db.Barbars.Find(id);
            if (barbar == null)
            {
                return HttpNotFound();
            }
            return View(barbar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barbar barbar)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileNameWithoutExtension(barbar.UserImagePath.FileName);
                var extension = Path.GetExtension(barbar.UserImagePath.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                barbar.ImagePath = "~/Content/uploaded/" + filename;
                filename = Path.Combine(Server.MapPath("~/Content/uploaded/"), filename);
                barbar.UserImagePath.SaveAs(filename);

                db.Entry(barbar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barbar);
        }
        public ActionResult Delete(int id)
        {
            Barbar barbar = db.Barbars.Find(id);
            db.Barbars.Remove(barbar);
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
