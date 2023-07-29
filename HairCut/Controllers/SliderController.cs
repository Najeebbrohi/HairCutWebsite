using HairCut.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HairCut.Controllers
{
    [Authorize]
    public class SliderController : Controller
    {
        HaircutEntities db = new HaircutEntities();
        // GET: Slider
        public ActionResult Index()
        {
            //var publicationsList = (from eachPub in db.Sliders select eachPub).ToList();
            //return View(db.Sliders.ToList());

            var list = db.Sliders.ToList();
            //ViewBag.List = list;
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Slider slider)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileNameWithoutExtension(slider.UserImagePath.FileName);
                    var extension = Path.GetExtension(slider.UserImagePath.FileName);
                    fileName = fileName +DateTime.Now.ToString("yyddssff") + extension;
                    slider.ImgPath = "~/Content/uploaded/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/uploaded/"), fileName);
                    slider.UserImagePath.SaveAs(fileName);

                    db.Sliders.Add(slider);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Slider");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Edit(int id)
        {
            //var List = db.Sliders.Where(x => x.SliderId == id).FirstOrDefault();
            //ViewBag.List = List;
            Slider List = db.Sliders.Single(x => x.SliderId == id);
            return View(List);
        }
        [HttpPost]
        public ActionResult Edit(Slider slider)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileNameWithoutExtension(slider.UserImagePath.FileName);
                    var extension = Path.GetExtension(slider.UserImagePath.FileName);
                    filename = filename + DateTime.Now.ToString("yyddssff") + extension;
                    slider.ImgPath = "~/Content/uploaded/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Content/uploaded/"), filename);
                    slider.UserImagePath.SaveAs(filename);

                    db.Entry(slider).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Slider");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Delete(int id)
        {
            var del = db.Sliders.Find(id);
            db.Sliders.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}