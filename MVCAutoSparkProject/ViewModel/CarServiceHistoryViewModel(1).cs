using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAutoSparkProject.Models;

namespace MVCAutoSparkProject.ViewModel
{
    public class CarServiceHistoryViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<ServiceHistory>ServiceHistories { get; set; }
    }
}