using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.Models
{
    public class ServiceShoppingCart
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}