using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.Models
{
    public class ServiceHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Miles { get; set; }
       
       // public double Price { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
        
        
    }
}