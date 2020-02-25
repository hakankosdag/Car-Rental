using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.Models.EntityFramework;
using CarRental.Areas.Admin.Models.Cars;

namespace CarRental.Areas.Admin.Controllers
{
    public class CarsManagementController : Controller
    {
        DBEntities db = new DBEntities();

        // GET: Admin/Cars
        public ActionResult Index()
        {
            Car model = new Car();
            model.arabaList = db.Araba.OrderBy(m=>m.Marka).ToList();

            return View(model);
        }

        public ActionResult NewCar(int? id)
        {
            NewCar model = new NewCar();
            Araba araba = new Araba();

            if (id != null)
            {
                araba = db.Araba.Where(m => m.ID == id).First();
            }

            model.araba = araba;
            return View(model);
        }

        [HttpPost]
        public ActionResult NewCar(NewCar model)
        {
            if (model.araba.ID == 0)
            {
                model.araba.Resim = "images/cla180.jpg";
            }
            db.Araba.Add(model.araba);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}