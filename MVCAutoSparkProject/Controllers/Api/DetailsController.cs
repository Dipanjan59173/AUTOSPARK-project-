using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCAutoSparkProject.Models;

namespace MVCAutoSparkProject.Controllers.Api
{
    public class DetailsController : ApiController
    {
        private ApplicationDbContext _context;
        public DetailsController()
        {
            _context = new ApplicationDbContext();
        }
        //Get api/details/1
        //public IHttpActionResult GetServiceDetails(int id)
        //{
        //    //if (id <= 0)
        //    //    return BadRequest("Not a valid Car Id");
        //    //var serviceHistDetails = _context.Details.SingleOrDefault(c => c.Id == id);
        //    //if (serviceHistDetails == null)
        //    //    return NotFound();
        //    //return Ok(serviceHistDetails);
        //}
    }
}
