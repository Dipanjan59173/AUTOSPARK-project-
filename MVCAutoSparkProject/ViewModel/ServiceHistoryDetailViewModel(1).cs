using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAutoSparkProject.Models;

namespace MVCAutoSparkProject.ViewModel
{
    public class ServiceHistoryDetailViewModel
    {
        public IEnumerable<Detail> Details { get; set; }
        public ServiceHistory ServiceHistory{ get; set; }
    }
}