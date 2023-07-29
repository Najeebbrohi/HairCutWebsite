using HairCut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HairCut.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private HaircutEntities db = new HaircutEntities();

        public ActionResult Index()
        {
            //var slider = db.Sliders.ToList();
            var slider = (from d in db.Sliders select d).ToList();
            ViewBag.Slider = slider;

            var services = (from d in db.Services select d).Take(9).ToList();
            ViewBag.Services = services;

            var price = (from d in db.Prices select d).ToList();
            ViewBag.Prices = price;

            var barbar = (from d in db.Barbars select d).ToList();
            ViewBag.Barbars = barbar;

            var working = (from d in db.Working_Hours select d).ToList();
            ViewBag.Working = working;

            var testmonial = (from d in db.Testimonials select d).ToList();
            ViewBag.Testimonial = testmonial;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    ViewBag.Msg = "Your Message has been sent";
                    return RedirectToAction("Contact","Home");

                }
                else
                {
                    ViewBag.Msg = "Failed";
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public ActionResult Services()
        {
            var ServicesList = db.Services.ToList();
            var Testimonial = (from t in db.Testimonials select t).ToList();
            ViewBag.Testionials = Testimonial;
            return View(ServicesList);
        }
        public ActionResult Price()
        {
            var Price = db.Prices.ToList();
            return View(Price);
        }
        public ActionResult Barbar()
        {
            var Barbar = db.Barbars.ToList();
            return View(Barbar);
        }
        public ActionResult WorkingHours()
        {
            var Working = db.Working_Hours.ToList();
            return View(Working);
        }
        public ActionResult Testimonial()
        {
            var Testimonial = db.Testimonials.ToList();
            return View(Testimonial);
        }
    }
}