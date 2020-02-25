using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Models.EntityFramework;

namespace CarRental.Areas.Admin.Models.Cars
{
    public class Car
    {
        public List<Araba> arabaList { get; set; }
    }
}