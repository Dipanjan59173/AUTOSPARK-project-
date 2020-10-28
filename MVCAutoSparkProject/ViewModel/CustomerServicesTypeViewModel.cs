using MVCAutoSparkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.ViewModel
{
    public class CustomerServicesTypeViewModel
    {
        public IEnumerable<ServiceType> ServiceTypes { get; set; }
       
        public Car Car { get; set; }
        
        public ServiceHistory ServiceHistory { get; set; }
        public ServiceSummary ServiceSummary { get; set; }
    }
}
