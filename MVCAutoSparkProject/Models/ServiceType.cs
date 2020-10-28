using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Service type is mandatory")]
        public string ServiceTpe { get; set; }
        [Required(ErrorMessage = "Price is mandatory")]
        public double Price { get; set; }
    }
}