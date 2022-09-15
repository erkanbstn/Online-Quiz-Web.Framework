using OnlineTest.Models;
using OnlineTest.UI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTest.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string UserMail, string UserPassword)
        {
            var db = new AppDbContext();
            var usercontrol = db.Users.FirstOrDefault(u => u.UserName == UserMail && u.Password == UserPassword);
            if (usercontrol != null)
            {
                FormsAuthentication.SetAuthCookie(usercontrol.UserName, false);
                Session["UserID"] = usercontrol.Id;
                if (usercontrol.Role == "Öğrenci")
                {
                    return RedirectToAction("GetTest", "OnlineTest");
                }
                else
                {
                    return RedirectToAction("Ogrenciler", "YtuPanel");
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            CacheHelper.Id = 1;
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("SignIn");
        }
    }
}