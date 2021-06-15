using CollegeSporting.Models;
using CollegeSporting.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CollegeSporting.Controllers
{
    public class RegistrationController : Controller
    {
        RegistrationUnitOfWork _registrationUnitOfWork;

        public RegistrationController(RegistrationUnitOfWork registrationUnitOfWork, IRepository<Registration> repository)
        {
            _registrationUnitOfWork = registrationUnitOfWork;
        }

        [Route("registrations")]
        public IActionResult List(long id)
        {
            if (id <= 0) // Checking that the id is not valid
            {
                return RedirectToAction("GetCustomer"); // Redirect to page GetCustomer
            }
            var customer = _registrationUnitOfWork.Customers.Get(id);
            var registrations = _registrationUnitOfWork.Registrations.Find(registration => registration.CustomerId == customer.Id); // Find registration for choosen customer
            var registrationsViewModel = new RegistrationsViewModel(_registrationUnitOfWork.Products.GetAll(),registrations, customer);
            return View(registrationsViewModel);
        }

        public ViewResult GetCustomer()
        {
            List<CustomerViewModel> customers = new List<CustomerViewModel>();
            foreach (var customer in _registrationUnitOfWork.Customers.GetAll())
                customers.Add(new CustomerViewModel
                {
                    Id = customer.Id,
                    FullName = customer.GetFullName()
                });
            ViewBag.Customers = customers;
            return View();
        }

        [HttpPost]
        public IActionResult GetCustomer(long id)
        {
            ModelState.Clear(); // Clear model, from correct displaying model error (EF bug)
            if (id <= 0) // Checking that the id is not valid
            {
                ModelState.AddModelError("Id", "Customer not selected");
                List<CustomerViewModel> customers = new List<CustomerViewModel>();
                foreach (var customer in _registrationUnitOfWork.Customers.GetAll())
                    customers.Add(new CustomerViewModel
                    {
                        Id = customer.Id,
                        FullName = customer.GetFullName()
                    });
                ViewBag.Customers = customers;
                return View();
            }
            HttpContext.Session.SetString("CustomerId", id.ToString()); // set the CustomerId in the session
            return RedirectToAction("List", new { id });
        }

        public RedirectToActionResult DeleteRegistration(long id)
        {
            var registration = _registrationUnitOfWork.Registrations.Get(id);
            _registrationUnitOfWork.Registrations.Remove(registration);
            _registrationUnitOfWork.Save();
            TempData["message"] = $"product '{_registrationUnitOfWork.Products.Get(id).Name}' registration has been removed"; // Creating temp data for view page
            var customerId = long.Parse(HttpContext.Session.GetString("CustomerId")); // get the Customer id from the session
            return RedirectToAction("List", new { id = customerId });
        }

        [HttpPost]
        public RedirectToActionResult Register(Registration registration)
        {
            _registrationUnitOfWork.Registrations.Create(registration);
            _registrationUnitOfWork.Save();
            TempData["message"] = $"product '{_registrationUnitOfWork.Products.Get(registration.ProductId).Name}' has been registered for customer '{_registrationUnitOfWork.Customers.Get(registration.CustomerId).GetFullName()}'"; // Creating temp data for view page
            return RedirectToAction("List", new { id = registration.CustomerId });
        }
    }
}
