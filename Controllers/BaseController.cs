using CarRental.Models;
using CarRental.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DBEntities db = new DBEntities();
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var mail = filterContext.HttpContext.User.Identity.Name;
                Musteri data = db.Musteri.Find(mail);

                var info = new KullaniciModel
                {
                    ID = data.ID,
                    FullName = data.Ad + " " + data.Soyad
                };

                TempData["userInfo"] = info;
            }
            else
            {

            }

            base.OnActionExecuting(filterContext);
        }
    }
}