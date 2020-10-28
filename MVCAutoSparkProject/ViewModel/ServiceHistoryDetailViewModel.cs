using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAutoSparkProject.Models;

namespace MVCAutoSparkProject.ViewModel
{
    public class ServiceHistoryDetailViewModel
    {
        
        public ServiceHistory ServiceHistories{ get; set; }
        public ServiceType ServiceType { get; set; }
    }
}