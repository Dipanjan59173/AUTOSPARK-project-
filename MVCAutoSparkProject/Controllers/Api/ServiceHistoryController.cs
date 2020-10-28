using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCAutoSparkProject.Models;

namespace MVCAutoSparkProject.Controllers.Api
{
    public class ServiceHistoryController : ApiController
    {
        private ApplicationDbContext _context;
        public ServiceHistoryController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/ServiceHistory/3
        public IHttpActionResult GetServiceHistory(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Car Id");
            var serviceHist = _context.ServiceHistories.SingleOrDefault(c => c.Id == id);
            if (serviceHist == null)
                return NotFound();
            return Ok(serviceHist);
        }
    }
}
