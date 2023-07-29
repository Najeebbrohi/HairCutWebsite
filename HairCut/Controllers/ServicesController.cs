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
    public class ServicesController : Controller
    {
        private HaircutEntities db = new HaircutEntities();
        // GET: Services
        public ActionResult Index()
        {
            var List = db.Services.ToList();
            //ViewBag.List = List;
            return View(List);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileNameWithoutExtension(service.UserImagePath.FileName);
                var extension = Path.GetExtension(service.UserImagePath.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                service.ImgPath = "~/Content/uploaded/" + filename;
                filename = Path.Combine(Server.MapPath("~/Content/uploaded/"), filename);
                service.UserImagePath.SaveAs(filename);

                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                var filename = Path.GetFileNameWithoutExtension(service.UserImagePath.FileName);
                var extension = Path.GetExtension(service.UserImagePath.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                service.ImgPath = "~/Content/uploaded/" + filename;
                filename = Path.Combine(Server.MapPath("~/Content/uploaded/"), filename);
                service.UserImagePath.SaveAs(filename);

                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }
        public ActionResult Delete(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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
