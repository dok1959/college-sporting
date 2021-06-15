using CollegeSporting.Models;
using CollegeSporting.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSporting.Controllers
{
    public class TechniciansController : Controller
    {
        private IRepository<Technician> _repository;

        public TechniciansController(IRepository<Technician> repository) // Constructor Dependency Injection
        {
            _repository = repository;
        }

        [Route("technicians")]
        public ViewResult Index() => View(_repository.GetAll());

        public ViewResult AddTechnician()
        {
            ViewBag.Title = "Add Technician"; // Passing the page title
            ViewBag.Action = "AddTechnician"; // Passing the method action
            return View("UpsertTechnician");
        }

        [HttpPost]
        public IActionResult AddTechnician(Technician technician)
        {
            if (!ModelState.IsValid) // Checking that the model is not valid
            {
                ViewBag.Title = "Add Technician"; // Passing the page title
                ViewBag.Action = "AddTechnician"; // Passing the method action
                return View("UpsertTechnician", technician);
            }
            _repository.Create(technician);
            _repository.Save();
            TempData["message"] = $"{technician.Name} has been added"; // Creating temp data for view page
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult EditTechnician(long id)
        {
            ViewBag.Title = "Edit Technician"; // Passing the page title
            ViewBag.Action = "EditTechnician"; // Passing the method action
            return View("UpsertTechnician", _repository.Get(id));
        }

        [HttpPost]
        public IActionResult EditTechnician(Technician technician)
        {
            if (!ModelState.IsValid) // Checking that the model is not valid
            {
                ViewBag.Title = "Edit Technician"; // Passing the page title
                ViewBag.Action = "EditTechnician"; // Passing the method action
                return View("UpsertTechnician", technician);
            }
            _repository.Update(technician);
            _repository.Save();
            TempData["message"] = $"{technician.Name} has been edited"; // Creating temp data for view page
            return RedirectToAction("Index");
        }

        [HttpGet]
        public RedirectToActionResult DeleteTechnician(long id)
        {
            var technician = _repository.Get(id);
            if (technician != null)
            {
                _repository.Remove(technician);
                _repository.Save();
                TempData["message"] = $"{technician.Name} has been removed"; // Creating temp data for view page
            }
            return RedirectToAction("Index");
        }
    }
}
