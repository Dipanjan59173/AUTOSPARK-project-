using MVCAutoSparkProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAutoSparkProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Secondhand()
        {
            var carlist = _context.Secondhands.ToList();
            return View(carlist);

        }

        public ActionResult Details(int? id)
        {

            Secondhand singleProduct = _context.Secondhands.SingleOrDefault(s => s.Id == id);
            if (singleProduct == null)
                return HttpNotFound();
            else
                return View(singleProduct);
        }

        public ActionResult ConfirmAppointment()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}