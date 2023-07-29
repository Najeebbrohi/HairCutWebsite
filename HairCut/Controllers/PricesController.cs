using HairCut.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HairCut.Controllers
{
    [Authorize]
    public class PricesController : Controller
    {
        private HaircutEntities db = new HaircutEntities();
        public ActionResult Index()
        {
            var List = db.Prices.ToList();
            return View(List);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Price price)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Prices.Add(price);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Prices");
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
            var List = db.Prices.Where(x => x.Id == id).FirstOrDefault();
            return View(List);
        }
        [HttpPost]
        public ActionResult Edit(Price price)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(price).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Prices");
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
            var del = db.Prices.Find(id);
            db.Prices.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index", "Prices");
        }
    }
}