using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCAutoSparkProject.Models;

namespace MVCAutoSparkProject.Controllers.Api
{
    public class CarController : ApiController
    {
        private ApplicationDbContext _context;
        public CarController()
        {
            _context = new ApplicationDbContext();
        }
        //PUT api/Car/1
        [HttpPut]
        public IHttpActionResult EditCustomerCar(int id, Car car)
        {
            if (id <= 0)
                return BadRequest("Not a valid car Id");
            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == car.Id);
            if (carInDb == null)
                return NotFound();
            carInDb.VIN = car.VIN;
            carInDb.BrandName = car.BrandName;
            carInDb.Model = car.Model;
            carInDb.Style = car.Style;
            carInDb.Year = car.Year;
            carInDb.Color = car.Color;
            carInDb.CustomerId = car.CustomerId;
            _context.SaveChanges();
            return Ok();
        }
    }
}
