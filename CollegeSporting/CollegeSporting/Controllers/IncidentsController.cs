using CollegeSporting.Models;
using CollegeSporting.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CollegeSporting.Controllers
{
    public class IncidentsController : Controller
    {
        private IncidentsUnitOfWork _incidentsUnitOfWork;
        public IncidentsController(IncidentsUnitOfWork incidentsUnitOfWork) // Constructor Dependency Injection
        {
            _incidentsUnitOfWork = incidentsUnitOfWork;
        }

        [HttpGet]
        [Route("incidents/{filter?}")]
        public ViewResult Index(string filter = "all")
        {
            IEnumerable<Incident> incidents = null;
            switch(filter)
            {
                case "unassigned":
                    incidents = _incidentsUnitOfWork.Incidents.Find(incident => incident.TechnicianId == null); // Finding incidents without technicians
                    break;
                case "open":
                    incidents = _incidentsUnitOfWork.Incidents.Find(incident => incident.DateClosed == null); // Finding incidents without date closed
                    break;
                default:
                    incidents = _incidentsUnitOfWork.Incidents.GetAll();
                    break;
            }
            IncidentsViewModel viewModel = new IncidentsViewModel
                (incidents,
                _incidentsUnitOfWork.Customers.GetAll(),
                _incidentsUnitOfWork.Products.GetAll()); // Creating a view model of incidents
            viewModel.Filter = filter; // Passing filter parameter to view model
            return View(viewModel);
        }

        public ViewResult AddIncident()
        {
            ViewBag.Title = "Add Incident"; // Passing the page title to page
            List<CustomerViewModel> customers = new List<CustomerViewModel>();
            foreach(var rawCustomer in _incidentsUnitOfWork.Customers.GetAll()) // Converting Customer to CustomerViewModel
            {
                customers.Add(CreateCustomerVMFromCustomer(rawCustomer));
            }
            var incidentViewModel = new IncidentViewModel
            {
                Incident = null,
                Customers = customers,
                Products = _incidentsUnitOfWork.Products.GetAll(),
                Technicians = _incidentsUnitOfWork.Technicians.GetAll(),
                ActionPage = "AddIncident"
            };
            return View("UpsertIncident", incidentViewModel);
        }

        [HttpPost]
        public IActionResult AddIncident(Incident incident)
        {
            ValidateModel(incident);

            if (!ModelState.IsValid) // Checking that the model is not valid
            {
                ViewBag.Title = "Add Incident"; // Passing the page title to page
                List<CustomerViewModel> customers = new List<CustomerViewModel>();
                foreach (var rawCustomer in _incidentsUnitOfWork.Customers.GetAll()) // Converting Customer to CustomerViewModel
                {
                    customers.Add(CreateCustomerVMFromCustomer(rawCustomer));
                }
                var incidentViewModel = new IncidentViewModel
                {
                    Incident = incident,
                    Customers = customers,
                    Products = _incidentsUnitOfWork.Products.GetAll(),
                    Technicians = _incidentsUnitOfWork.Technicians.GetAll(),
                    ActionPage = "AddIncident"
                };
                return View("UpsertIncident", incidentViewModel);
            }

            _incidentsUnitOfWork.Incidents.Create(incident);
            _incidentsUnitOfWork.Save();
            TempData["message"] = $"{incident.Title} has been added"; // Creating temp data for view page
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult EditIncident (long id)
        {
            ViewBag.Title = "Edit Incident"; // Passing the page title to page
            Incident incident = _incidentsUnitOfWork.Incidents.Get(id);
            List<CustomerViewModel> customers = new List<CustomerViewModel>();
            foreach (var rawCustomer in _incidentsUnitOfWork.Customers.GetAll()) // Converting Customer to CustomerViewModel
            {
                customers.Add(CreateCustomerVMFromCustomer(rawCustomer));
            }
            var incidentViewModel = new IncidentViewModel
            {
                Incident = incident,
                Customers = customers,
                Products = _incidentsUnitOfWork.Products.GetAll(),
                Technicians = _incidentsUnitOfWork.Technicians.GetAll(),
                ActionPage = "EditIncident"
            };
            return View("UpsertIncident", incidentViewModel);
        }

        [HttpPost]
        public IActionResult EditIncident(Incident incident)
        {
            ValidateModel(incident);

            if (!ModelState.IsValid) // Checking that the model is not valid
            {
                ViewBag.Title = "Edit Incident"; // Passing the page title to page
                List<CustomerViewModel> customers = new List<CustomerViewModel>();
                foreach (var rawCustomer in _incidentsUnitOfWork.Customers.GetAll()) // Converting Customer to CustomerViewModel
                {
                    customers.Add(CreateCustomerVMFromCustomer(rawCustomer));
                }
                var incidentViewModel = new IncidentViewModel
                {
                    Incident = incident,
                    Customers = customers,
                    Products = _incidentsUnitOfWork.Products.GetAll(),
                    Technicians = _incidentsUnitOfWork.Technicians.GetAll(),
                    ActionPage = "EditIncident"
                };
                return View("UpsertIncident", incidentViewModel);
            }

            _incidentsUnitOfWork.Incidents.Update(incident);
            _incidentsUnitOfWork.Save();
            TempData["message"] = $"{incident.Title} has been edited"; // Creating temp data for view page
            return RedirectToAction("Index");
        }

        [HttpGet]
        public RedirectToActionResult DeleteIncident(long id)
        {
            var incident = _incidentsUnitOfWork.Incidents.Get(id);
            if (incident != null)
            {
                _incidentsUnitOfWork.Incidents.Remove(incident);
                _incidentsUnitOfWork.Save();
                TempData["message"] = $"{incident.Title} has been removed"; // Creating temp data for view page
            }
            return RedirectToAction("Index");
        }

        private void ValidateModel(Incident incident) // Method for checking the correctness of model properties
        {
            if (incident.ProductId <= 0)
            {
                ModelState.AddModelError("ProductId", "Продукт не указан");
            }
            if (incident.CustomerId <= 0)
            {
                ModelState.AddModelError("CustomerId", "Клиент не указан");
            }
        }

        private CustomerViewModel CreateCustomerVMFromCustomer(Customer rawCustomer) // Converting Customer to CustomerViewModel
        {
            CustomerViewModel customer = new CustomerViewModel
            {
                Id = rawCustomer.Id,
                FullName = rawCustomer.GetFullName()
            };
            return customer;
        }
    }
}