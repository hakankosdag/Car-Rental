using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Models.EntityFramework;
namespace CarRental.Models.Cars
{
    public class RentACarModel
    {
        public Kiralik kiralik { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime VerisTarihi { get; set; }
    }
}