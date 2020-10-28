using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAutoSparkProject.Models;

namespace MVCAutoSparkProject.ViewModel
{
    public class CarServiceViewModel
    {
        public Car Car { get; set; }
        public ServiceHistory ServiceHistory { get; set; }
        public Detail Detail { get; set; }
        public List<ServiceType> ServiceTypesList { get; set; }
        public List<ServiceShoppingCart> ServiceShoppingCarts { get; set; }

        public int SelectedServiceId { get; set; }
        public SelectList ServiceTypesListNew { get; set; }

        public ServiceType AddSingleSeviceDetails { get; set; }

        public int newvalue { get; set; }

    }
}
