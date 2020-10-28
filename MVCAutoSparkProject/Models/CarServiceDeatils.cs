using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.Models
{
    public class CarServiceDeatils
    {
        public double Miles { get; set; }
        public string dateofservice { get; set; }

        public List<ServiceType> ServiceHistory { get; set; }
        public string CarId { get; set; }


    }
}