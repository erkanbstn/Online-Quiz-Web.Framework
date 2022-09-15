using Microsoft.Ajax.Utilities;
using OnlineTest.Models;
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
    public class OnlineTestController : Controller
    {
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult GetTest(string askincomplete)
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            var db = new AppDbContext();
            var usercontrol2 = db.Answers.FirstOrDefault(a => a.AskID == 80 && a.UserID == userid);
            if (usercontrol2 != null)
            {
                var u = db.Users.Find(userid);
                u.Status = true;
                db.SaveChanges();
                return RedirectToAction("Finish");
            }
            var usercontrol = db.Answers.FirstOrDefault(a => a.UserID == userid);
            if (usercontrol != null)
            {
                var askcontrol = db.Answers.Where(a => a.UserID == userid).OrderByDescending(a => a.AskID).FirstOrDefault();
                if (askcontrol != null)
                {
                    CacheHelper.Id = ++askcontrol.AskID;
                }
            }
            else
            {
                CacheHelper.Id = 1;
            }

            if (askincomplete != string.Empty)
            {
                ViewBag.askincomplete = askincomplete;
            }
            if (CacheHelper.Aski == 0)
            {
                ViewBag.welcome = "Lütfen Cevaplarınızı Soruların Altındaki Kutucuklara \"A-B-C-D\" Şeklinde Belirtiniz. Başarılar !";
            }
            else
            {
                ViewBag.welcome = null;
            }
            UnitTest unitTest = new UnitTest()
            {
                Asks = db.Asks.Where(a => a.Id == CacheHelper.Id).ToList(),
            };
            return View(unitTest);
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [HttpPost]
        public ActionResult GetTest(string AnswerContent, int askid)
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            var db = new AppDbContext();
            var ans = new Answer();
            ans.Content = AnswerContent.ToUpper();
            ans.UserID = userid;
            ans.AskID = askid;

            string[] Digist = { "A", "a", "B", "b", "C", "c", "D", "d", "E", "e" };
            foreach (var digit in Digist)
            {
                if (ans.Content.Contains(digit))
                {
                    CacheHelper.WordControl = true;
                    break;
                }
                else
                {
                    CacheHelper.WordControl = false;
                }
            }
            if (CacheHelper.WordControl)
            {
                db.Answers.Add(ans);
                db.SaveChanges();
                CacheHelper.Id = ++askid;
                CacheHelper.Aski++;
                ViewBag.askincomplete = null;
                return RedirectToAction("GetTest");
            }
            else
            {
                return RedirectToAction("GetTest", new { askincomplete = $"Lütfen Yalnızca 'A-B-C-D,a-b-c-d' Karakterlerini Kullanınız." });
            }
        }

        public ActionResult Finish()
        {
            return View();
        }
    }
}