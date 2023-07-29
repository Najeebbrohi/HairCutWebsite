using HairCut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HairCut.Controllers
{
    public class AdminController : Controller
    {
        HaircutEntities db = new HaircutEntities();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {
            var IsAuth = db.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
            if(IsAuth != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Msg = "Username or Password are incorrect";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Admin");
        }
    }
}