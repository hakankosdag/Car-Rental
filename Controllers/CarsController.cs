using CarRental.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CarRental.Models;
using CarRental.Models.Cars;

namespace CarRental.Controllers
{

    public class CarsController : BaseController
    {

        DBEntities db = new DBEntities();
        // GET: Cars
        public ActionResult Index()
        {
            var model = db.Araba.ToList();
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba model = db.Araba.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult Rent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentACarModel model = new RentACarModel();
            model.kiralik = new Kiralik();
            Araba model2 = db.Araba.Find(id);
            
            if (model2 == null)
            {
                return HttpNotFound();
            }
            model.kiralik.ArabaID = model2.ID;
            return View(model);
        }

        [HttpPost]
        public ActionResult Rent(RentACarModel model)
        {
            model.kiralik.AlmaTarihi = model.AlisTarihi;
            model.kiralik.TeslimTarihi = model.VerisTarihi;
            db.Kiralik.Add(model.kiralik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}