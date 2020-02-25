using CarRental.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarRental.Controllers
{
    public class CustomerController : BaseController
    {


        DBEntities db = new DBEntities();
        // GET: LogIn
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Musteri musteri)
        {
            var kullanici = db.Musteri.FirstOrDefault(x => x.Email == musteri.Email && x.Sifre == musteri.Sifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.Email,false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz E-mail yada Şifre.";
                return View();
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult SingUp()
        {
            var model = new Musteri();

            return View("SingUp",model);
        }
        [HttpPost]
        public ActionResult Save(Musteri musteri)
        {
            if (musteri.ID == 0)
            {
                db.Musteri.Add(musteri);
            }
            else // guncelleme için
            {

            }
            db.SaveChanges();
            return RedirectToAction("Login");
        }

    }
}