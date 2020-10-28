using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.Models
{
    public class ServiceAvail
    {
        public int Id { get; set; }
        public string ServiceType { get; set; }
        public Car Car { get; set; }

        public Customer Customer { get; set; }
    }
       
}