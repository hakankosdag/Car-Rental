using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Models.EntityFramework;
namespace CarRental.Areas.Admin.Models.Dashboard
{
    public class DashboardModel
    {
        public List<Kiralik> kiralikList { get; set; }
        public List<Araba> arabaList { get; set; }
    }
}