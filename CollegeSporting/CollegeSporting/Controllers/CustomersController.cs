using CollegeSporting.Models;
using CollegeSporting.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeSporting.Controllers
{
    public class CustomersController : Controller
    {
        private CustomersUnitOfWork _customersUnitOfWork;

        public CustomersController(CustomersUnitOfWork customersUnitOfWork) // Constructor Dependency Injection
        {
            _customersUnitOfWork = customersUnitOfWork;
        }

        [Route("customers")]
        public ViewResult Index() => View(_customersUnitOfWork.Customers.GetAll());

        public ViewResult AddCustomer()
        {
            ViewBag.Title = "Add Customer"; // Passing the page title to page
            ViewBag.Action = "AddCustomer"; // Passing the method action to page
            ViewBag.Countries = new SelectList(_customersUnitOfWork.Countries.GetAll(), "Id", "Name"); // Passing all countries to view page
            return View("UpsertCustomer");
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            ValidateModel(customer);
            if (!ModelState.IsValid) // Checking that the model is not valid
            {
                ViewBag.Title = "Add Customer"; // Passing the page title to page
                ViewBag.Action = "AddCustomer"; // Passing the method action to page
                ViewBag.Countries = new SelectList(_customersUnitOfWork.Countries.GetAll(), "Id", "Name", customer.CountryId); // Passing all countries to view page
                return View("UpsertCustomer", customer);
            }
            _customersUnitOfWork.Customers.Create(customer);
            _customersUnitOfWork.Save();
            TempData["message"] = $"{customer.GetFullName()} has been added"; // Creating temp data for view page
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult EditCustomer(long id)
        {
            ViewBag.Title = "Edit Customer"; // Passing the page title to page
            ViewBag.Action = "EditCustomer"; // Passing the method action to page
            Customer customer = _customersUnitOfWork.Customers.Get(id);
            ViewBag.Countries = new SelectList(_customersUnitOfWork.Countries.GetAll(), "Id", "Name", customer.CountryId); // Passing all countries to view page
            return View("UpsertCustomer", customer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            ValidateModel(customer);

            if (!ModelState.IsValid) // Checking that the model is not valid
            {
                ViewBag.Title = "Edit Customer"; // Passing the page title to page
                ViewBag.Action = "EditCustomer"; // Passing the method action to page
                ViewBag.Countries = new SelectList(_customersUnitOfWork.Countries.GetAll(), "Id", "Name", customer.CountryId); // Passing all countries to view page
                return View("UpsertCustomer", customer);
            }
            _customersUnitOfWork.Customers.Update(customer);
            _customersUnitOfWork.Save();
            TempData["message"] = $"{customer.GetFullName()} has been edited"; // Creating temp data for view page
            return RedirectToAction("Index");
        }

        [HttpGet]
        public RedirectToActionResult DeleteCustomer(long id)
        {
            var customer = _customersUnitOfWork.Customers.Get(id);
            if (customer != null)
            {
                _customersUnitOfWork.Customers.Remove(customer);
                _customersUnitOfWork.Save();
                TempData["message"] = $"{customer.GetFullName()} has been removed"; // Creating temp data for view page
            }
            return RedirectToAction("Index");
        }

        public void ValidateModel(Customer customer) // Method for checking the correctness of model properties
        {
            if (customer.CountryId == null || customer.CountryId <= 0)
            {
                ModelState.AddModelError("CountryId", "Required");
            }
            foreach(var cust in _customersUnitOfWork.Customers.GetAll()) // Finding email matching
                if(cust.Email == customer.Email && cust.Id != customer.Id)
                    ModelState.AddModelError("Email", "Email address already in use");
        }
    }
}
