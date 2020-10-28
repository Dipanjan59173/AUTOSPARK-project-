using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCAutoSparkProject.Models;
using System.Data.Entity;
using MVCAutoSparkProject.ViewModel;

namespace MVCAutoSparkProject.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers/
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            //return _context.Customers.ToList();
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }
        //GET /api/customers/1
        public IHttpActionResult GetCustomerCar(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Customer Id");
            var vm = new CustomerCarViewModel
            {
                Cars = _context.Cars.Where(c => c.CustomerId == id).ToList(),
                Customer = _context.Customers.FirstOrDefault(c => c.Id == id)
            };
            return Ok(vm);
        }
        //PUT /api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid data ");
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            customerInDb.Name = customer.Name;
            customerInDb.EmailId= customer.EmailId;
            customerInDb.PhoneNumber = customer.PhoneNumber;
            _context.SaveChanges();
            return Ok();
        }
        //DELETE /api/customers/1
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Customer Id");
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
            ;
        }
    }
}
