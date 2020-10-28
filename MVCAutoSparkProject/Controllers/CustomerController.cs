using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAutoSparkProject.Models;
using MVCAutoSparkProject.ViewModel;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace MVCAutoSparkProject.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // List<CustomerCarViewModel> Cl;

        ApplicationDbContext _context;
        // Customer c;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            //var customerlist = _context.Customers.ToList();
            //return View(customerlist);
            //var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            //**********WITH API***********
            if(User.IsInRole("CanManageCustomers"))
            {
                IEnumerable<Customer> customers;
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Customer").Result;
                customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                return View(customers);
            }
            else
            {
                IEnumerable<Customer> customers;
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Customer").Result;
                customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                return View("IndexForUser",customers);
            }
          
        }
        


        public ActionResult New(int id)
        {
            if (User.IsInRole("CanManageCustomers"))
            {
                HttpResponseMessage mresponse = GlobalVariables.webApiClient.GetAsync("Customers").Result;
                HttpResponseMessage cresponse = GlobalVariables.webApiClient.GetAsync($"Customer/{id}").Result;
                var vm = new CustomerCarViewModel
                {
                    Cars = _context.Cars.Where(c => c.CustomerId == id).ToList(),
                    Customer = _context.Customers.FirstOrDefault(c => c.Id == id)
                    //Customer = cresponse.Content.ReadAsAsync<Customer>().Result,
                    //Cars = cresponse.Content.ReadAsAsync<IEnumerable<Car>>().Result
                };
                return View("New", vm);
            }
            else
            {
                HttpResponseMessage mresponse = GlobalVariables.webApiClient.GetAsync("Customers").Result;
                HttpResponseMessage cresponse = GlobalVariables.webApiClient.GetAsync($"Customer/{id}").Result;
                var vm = new CustomerCarViewModel
                {
                    Cars = _context.Cars.Where(c => c.CustomerId == id).ToList(),
                    Customer = _context.Customers.FirstOrDefault(c => c.Id == id)
                };
                return View("NewForUser", vm);
            }
            

        }
        public ActionResult ServiceHistory(int id)
        {

            var vm = new CarServiceHistoryViewModel
            {
                ServiceHistories = _context.ServiceHistories.Distinct().Include(c => c.ServiceType).Where(c => c.CarId == id).ToList(),
                Car = _context.Cars.FirstOrDefault(c => c.Id == id),


            };
            return View("ServiceHistory", vm);
        }
        public ActionResult ServiceDetail(int id)
        {
            var vm = new ServiceHistoryDetailViewModel
            {
                //    //Details = _context.Details.Where(c => c.ServiceHistoryId == id).ToList(),
                //var serviceHistory = _context.ServiceHistories.Include(c => c.ServiceType).FirstOrDefault(c => c.Id == id);
                ServiceHistories = _context.ServiceHistories.Include(c => c.ServiceType).SingleOrDefault(c => c.Id == id),
                ServiceType = _context.ServiceTypes.FirstOrDefault(c => c.Id == id)

            };
            return View("ServiceDetail", vm);

        }


        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");

            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            //else
            //{
            //    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            //    customerInDb.Name = customer.Name;
            //    customerInDb.PhoneNumber = customer.PhoneNumber;
            //    customerInDb.EmailId = customer.EmailId;

            //}
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [HttpPost]
        public ActionResult SaveEdit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");

            }
            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.EmailId = customer.EmailId;
            customerInDb.Address = customer.Address;
            customer.PostalCode = customer.PostalCode;
            customerInDb.City = customer.City;
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer", customer);
        }
        public ActionResult Edit(int id)
        {
            var updateCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            return View(updateCustomer);
        }
        [HttpPost]
        public ActionResult SaveCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCarAdd");

            }
            if (car.Id == 0)
                _context.Cars.Add(car);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer", car);
        }
        [HttpPost]
        public ActionResult SaveEditCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View("CCarEdit");

            }
            var carInDb = _context.Cars.Single(c => c.Id == car.Id);
                carInDb.VIN = car.VIN;
                carInDb.BrandName = car.BrandName;
                carInDb.Model = car.Model;
                carInDb.Style = car.Style;
                carInDb.Year = car.Year;
                carInDb.Color = car.Color;
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer", car);
        }
 
         
        public ActionResult CCarEdit(int id)
        {
            var updateCar = _context.Cars.SingleOrDefault(c => c.Id == id);
            return View(updateCar);
        }
        public ActionResult DeleteCar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carTable = _context.Cars.Find(id);
            _context.Cars.Remove(carTable);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult ServiceType()
        {
            if (User.IsInRole("CanManageCustomers"))
            {
                IEnumerable<ServiceType> services;
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("SeviceType").Result;
                services = response.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;
                return View(services);
            }
            else
            {
                IEnumerable<ServiceType> services;
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("SeviceType").Result;
                services = response.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;
                return View("ServiceTypeForUser", services);
            }
        }
        public ActionResult NewServiceType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveService(ServiceType st)
        {
            //if (st.Id == 0)
            //    _context.ServiceTypes.Add(st);
            //else
            //{
            //    var serviceInDb = _context.ServiceTypes.Single(c => c.Id == st.Id);
            //    serviceInDb.ServiceTpe = st.ServiceTpe;
            //    serviceInDb.Price = st.Price;
            //}
            //_context.SaveChanges();
            //if (!ModelState.IsValid)
            //{
            //    return View("NewServiceType");

            //}

            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("SeviceType").Result;
            if (st.Id == 0)
                response = GlobalVariables.webApiClient.PostAsJsonAsync("SeviceType", st).Result;
            return RedirectToAction("ServiceType");
        }
        [HttpPost]
        public ActionResult SaveEditService(ServiceType st)
        {
            if (!ModelState.IsValid)
            {
                return View("EditServiceType");

            }
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("SeviceType").Result;
            response = GlobalVariables.webApiClient.PutAsJsonAsync($"SeviceType/{st.Id}", st).Result;
            return RedirectToAction("ServiceType");
        }
        
        public ActionResult EditServiceType(int id)
        {
            var updateService = _context.ServiceTypes.SingleOrDefault(c => c.Id == id);
            return View(updateService);
            //  HttpResponseMessage cresponse = GlobalVariables.webApiClient.GetAsync($"SeviceType/{id}").Result;
            //// var serviceType = cresponse.Content.ReadAsAsync<ServiceType>().Result;
            //  return View("EditServiceType");
        }

        //Add new Car 

        public ActionResult NewCarAdd()
        {

            return View();
        }
        [HttpGet]
        public ActionResult AddNewService(int id)
        {
            //    var addService = _context.ServiceTypes.ToList();
            //    return View(addService);
            var services = _context.ServiceTypes.ToList();
            var CarServiceVM = new CarServiceViewModel
            {
                Car = _context.Cars.Include(c => c.Customer).FirstOrDefault(c => c.Id == id),
                ServiceHistory = new ServiceHistory(),

                ServiceTypesList = services,
                ServiceTypesListNew = new SelectList(services, "Id", "ServiceTpe"),
                newvalue = 1
            };

            TempData["CarDetails"] = CarServiceVM.Car;
            TempData["services"] = services;
            TempData.Keep();

            return View(CarServiceVM);
        }
        public CarServiceViewModel AddToCart(CarServiceViewModel objCarServiceViewModelm, Car objcar)
        {
            ServiceType objServiceType = new ServiceType();
            var services = _context.ServiceTypes.ToList();
            objCarServiceViewModelm.ServiceTypesListNew = new SelectList(services, "Id", "ServiceTpe");
            objCarServiceViewModelm.newvalue = 5;
            objServiceType = services.Find(m => m.Id == objCarServiceViewModelm.SelectedServiceId);
            objCarServiceViewModelm.AddSingleSeviceDetails = objServiceType;
            return objCarServiceViewModelm;
        }

        [HttpPost]
        public ActionResult AddNewService(CarServiceDeatils listserviceHistory)
        {
            ServiceHistory objservice = new ServiceHistory();
            int serviceid = 0;
            string getDeptData = "";
            bool statusN = false;

            for (int i = 0; i < listserviceHistory.ServiceHistory.Count(); i++)
            {
                var ServiceType = listserviceHistory.ServiceHistory[i].ServiceTpe;
                List<ServiceType> modelData = TempData["services"] as List<ServiceType>;
                for (int j = 0; j < modelData.Count(); j++)
                {
                    if (modelData[j].ServiceTpe == ServiceType)
                    {
                        serviceid = modelData[j].Id;
                        objservice.Miles = Convert.ToDouble(listserviceHistory.Miles);
                        objservice.Date = Convert.ToDateTime(listserviceHistory.dateofservice);
                        objservice.ServiceTypeId = serviceid;
                        objservice.CarId = Convert.ToInt32(listserviceHistory.CarId);
                        _context.ServiceHistories.Add(objservice);
                        _context.SaveChanges();
                        statusN = true;
                    }
                }
            }
            if (statusN== true)
            {
                getDeptData = "{\"Data Save Successfully, in the history \"}";
            }
            else
            {
                getDeptData = "{\"code\":0,\"message\":\"Data not Save Successfully.\"}";
            }
            return Json(getDeptData);
           //return RedirectToAction("Index");
        }
        public CarServiceViewModel SaveCart(CarServiceViewModel objCarServiceViewModelm)
        {

            var services = _context.ServiceTypes.ToList();
            objCarServiceViewModelm.ServiceTypesListNew = new SelectList(services, "Id", "ServiceTpe");
            objCarServiceViewModelm.newvalue = 6;
            return objCarServiceViewModelm;
        }


        [HttpPost]
        public ActionResult SaveServiceSummary(ServiceSummary sc)
        {

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
