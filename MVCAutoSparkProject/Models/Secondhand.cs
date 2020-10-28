using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAutoSparkProject.Models
{
    public class Secondhand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Year { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}