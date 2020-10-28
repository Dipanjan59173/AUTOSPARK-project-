using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAutoSparkProject.Models;

namespace MVCAutoSparkProject.ViewModel
{
    public class CustomerCarViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Car> Cars { get; set; }

        
    }
}