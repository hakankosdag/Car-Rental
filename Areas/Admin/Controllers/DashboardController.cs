using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.Models.EntityFramework;
using CarRental.Areas.Admin.Models.Dashboard;
namespace CarRental.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            DBEntities db = new DBEntities();
            DashboardModel model = new DashboardModel();
            model.kiralikList = db.Kiralik.ToList();
            model.arabaList = db.Araba.ToList();
            return View(model);
        }
    }
}