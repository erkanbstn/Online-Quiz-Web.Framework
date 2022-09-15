using OnlineTest.Models;
using OnlineTest.UI.Models;
using OnlineTest.UI.Models.Entities;
using OnlineTest.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTest.UI.Controllers
{
    [Authorize]
    public class YtuPanelController : Controller
    {
        public ActionResult Ogrenciler()
        {
            var db = new AppDbContext();
            UnitTest unitTest = new UnitTest()
            {
                Users = db.Users.Where(a => a.Role == "Öğrenci").ToList(),
            };
            return View(unitTest);
        }
        public ActionResult Cevaplar(int id)
        {
            var db = new AppDbContext();
            UnitTest unitTest = new UnitTest()
            {
                Answers = db.Answers.Where(a => a.UserID == id).ToList(),
                Asks = db.Asks.ToList(),
            };
            ViewBag.kisi = db.Users.FirstOrDefault(a => a.Id == id).UserName.ToLower();
            ViewBag.toplamdogru = db.Answers.Where(a => a.UserID == id && a.Content == a.Ask.Correct).Count();
            ViewBag.toplamyanlis = db.Answers.Where(a => a.UserID == id && a.Content != a.Ask.Correct).Count();
            var mh = new MethodHelper();
            ViewBag.dogru = mh.CorrectControl(ViewBag.toplamdogru, ViewBag.toplamyanlis);
            return View(unitTest);
        }
        public ActionResult YeniOgrenci()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(UnitTest u)
        {
            var db = new AppDbContext();
            var user = new User
            {
                UserName = u.User.UserName,
                Password = u.User.Password,
                Status = false,
                Role = "Öğrenci"
            };
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Ogrenciler");
        }
        public ActionResult Duzenle(int id)
        {
            var db = new AppDbContext();
            var u = new UnitTest
            {
                User = db.Users.Find(id)
            };
            return View(u);
        }
        [HttpPost]
        public ActionResult Duzenle(UnitTest u)
        {
            var db = new AppDbContext();
            var user = db.Users.Find(u.User.Id);
            user.Id = u.User.Id;
            user.UserName = u.User.UserName;
            user.Password = u.User.Password;
            user.Status = u.User.Status;
            db.SaveChanges();
            return RedirectToAction("Ogrenciler");
        }
        public ActionResult Sil(int id)
        {
            var db = new AppDbContext();
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
            return RedirectToAction("Ogrenciler");
        }
    }
}