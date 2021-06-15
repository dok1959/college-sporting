using CollegeSporting.Models;
using CollegeSporting.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSporting.Controllers
{
    public class TechnicidentController : Controller
    {
        private IncidentsUnitOfWork _incidentsUnitOfWork;
        public TechnicidentController(IncidentsUnitOfWork incidentsUnitOfWork) // Constructor Dependency Injection
        {
            _incidentsUnitOfWork = incidentsUnitOfWork;
        }

        public IActionResult List(long id)
        {
            if (id <= 0) // Checking that the id is not valid
            {
                return RedirectToAction("Get"); // Redirect to page GetTechnician
            }
            var technician = _incidentsUnitOfWork.Technicians.Get(id);
            var incidents = _incidentsUnitOfWork.Incidents.Find(incident => incident.TechnicianId == id); // Get incidents for choosen technician
            var technicidentViewModel = new TechnicidentsViewModel(technician, _incidentsUnitOfWork.Products.GetAll(), _incidentsUnitOfWork.Customers.GetAll(), incidents);
            return View(technicidentViewModel);
        }

        public ViewResult Get()
        {
            ViewBag.Technicians = _incidentsUnitOfWork.Technicians.GetAll(); // Passing the all technicians
            return View();
        }

        [HttpPost]
        public IActionResult Get(long id)
        {
            ModelState.Clear(); // Clear model, from correct displaying model error (EF bug)
            if(id <= 0) // Checking that the id is not valid
            {
                ModelState.AddModelError("Id", "Technician not selected");
                ViewBag.Technicians = _incidentsUnitOfWork.Technicians.GetAll(); // Passing the list of technicians
                return View();
            }
            HttpContext.Session.SetString("TechnicianId", _incidentsUnitOfWork.Technicians.Get(id).ToString()); // set the technicianId in the session
            return RedirectToAction("List", new { id });
        }

        [HttpGet]
        public ViewResult Edit(long id)
        {
            var incident = _incidentsUnitOfWork.Incidents.Get(id);
            Technician technician = null;

            if (incident.TechnicianId != null)
                technician = _incidentsUnitOfWork.Technicians.Get((long)incident.TechnicianId);

            var technicidentViewModel = new TechnicidentViewModel(
                technician.Name, 
                _incidentsUnitOfWork.Products.Get(incident.ProductId).Name,
                _incidentsUnitOfWork.Customers.Get(incident.CustomerId).GetFullName(), 
                incident);

            return View(technicidentViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UpdateIncidentViewModel updateIncidentViewModel)
        {
            ModelState.Clear(); // Clear model, from correct displaying model error (EF bug)
            Incident incident;
            if (!ModelState.IsValid) // Checking that the model is not valid
            {
                incident = _incidentsUnitOfWork.Incidents.Get(updateIncidentViewModel.Id);
                Technician technician = null;

                if (incident.TechnicianId != null)
                    technician = _incidentsUnitOfWork.Technicians.Get((long)incident.TechnicianId);

                var technicidentViewModel = new TechnicidentViewModel(
                    technician.Name,
                    _incidentsUnitOfWork.Products.Get(incident.ProductId).Name,
                    _incidentsUnitOfWork.Customers.Get(incident.CustomerId).GetFullName(),
                    incident);

                return View(technicidentViewModel);
            }
            incident = _incidentsUnitOfWork.Incidents.Get(updateIncidentViewModel.Id);
            incident.Description = updateIncidentViewModel.Description;
            incident.DateClosed = updateIncidentViewModel.DateClosed;
            _incidentsUnitOfWork.Incidents.Update(incident);
            _incidentsUnitOfWork.Save();
            TempData["message"] = $"incident '{incident.Title}' has been edited"; // Creating temp data for view page
            return RedirectToAction("List", new { id = incident.TechnicianId });
        }
    }
}
