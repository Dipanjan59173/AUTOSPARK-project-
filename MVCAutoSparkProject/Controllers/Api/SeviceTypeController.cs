using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCAutoSparkProject.Models;

namespace MVCAutoSparkProject.Controllers.Api
{
    public class SeviceTypeController : ApiController
    {
        private ApplicationDbContext _context;
        public SeviceTypeController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/sevicetype/
        public IHttpActionResult GetServiceTypes()
        {
            var services = _context.ServiceTypes.ToList();
           
            if (services == null)
            {
                return NotFound();
            }
            return Ok(services);
        }
        //PUT api/sevicetype/1
        [HttpPut]
        public IHttpActionResult EditServiceType(int id, ServiceType serviceType)
        {
            if (!ModelState.IsValid)
                return BadRequest("model data is invalid");
            var serviceInDb = _context.ServiceTypes.SingleOrDefault(c => c.Id == serviceType.Id);
            if (serviceInDb == null)
                return NotFound();
            serviceInDb.Price = serviceType.Price;
            serviceInDb.ServiceTpe = serviceType.ServiceTpe;
            _context.SaveChanges();
            return Ok();
        }
        //POST api/sevicetype/
        [HttpPost]
        public IHttpActionResult CreateServiceType(ServiceType serviceType)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest("model data is invalid");
            _context.ServiceTypes.Add(serviceType);
            _context.SaveChanges();
            return Ok(serviceType);
        }
        //DELETE /api/sevicetype/1
        public IHttpActionResult DeleteService(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Servive type Id");
            var serviceInDb = _context.ServiceTypes.SingleOrDefault(c => c.Id == id);
            if (serviceInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.ServiceTypes.Remove(serviceInDb);
            _context.SaveChanges();
            return Ok();
            ;
        }


    }
}
