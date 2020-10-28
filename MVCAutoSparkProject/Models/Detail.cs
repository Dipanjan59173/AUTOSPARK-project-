using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string ServiceType { get; set; }
        public double Price { get; set; }
        public ServiceHistory ServiceHistory { get; set; }
        public int ServiceHistoryId { get; set; }
    }
}