using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.Models
{
    public class Car
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Engine Number is mandatory")]
        public string VIN { get; set; }
        [Required(ErrorMessage = "BrandName is mandatory")]
        public string BrandName { get; set; }
        [Required(ErrorMessage = "Color is mandatory")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Style field is mandatory")]
        public string Style { get; set; }
        [Required(ErrorMessage = "Date should be same as current date")]
        public DateTime Year { get; set; }
        [Required(ErrorMessage = "Model field is Required")]
        public string Model { get; set; }
        public Customer Customer { get; set; }
        [Display(Name ="Customer Id ")]
        public int CustomerId { get; set; }
      

    }
}