using CollegeSporting.Models;
using CollegeSporting.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSporting.Controllers
{
    public class ProductsController : Controller
    {
        private IRepository<Product> _repository;

        public ProductsController(IRepository<Product> repository) // Constructor Dependency Injection
        {
            _repository = repository;
        }

        [Route("products")]
        public ViewResult Index() => View(_repository.GetAll());

        public ViewResult AddProduct()
        {
            ViewBag.Title = "Add Product"; // Passing the page title
            ViewBag.Action = "AddProduct"; // Passing the method action
            return View("UpsertProduct");
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid) // Checking that the model is not valid
            {
                ViewBag.Title = "Add Product"; // Passing the page title
                ViewBag.Action = "AddProduct"; // Passing the method action
                return View("UpsertProduct", product);
            }
            _repository.Create(product);
            _repository.Save();
            TempData["message"] = $"{product.Name} has been added"; // Creating temp data for view page
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult EditProduct(long id)
        {
            ViewBag.Title = "Edit Product"; // Passing the page title
            ViewBag.Action = "EditProduct"; // Passing the method action
            return View("UpsertProduct", _repository.Get(id));
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid) // Checking that the model is not valid
            {
                ViewBag.Title = "Edit Product"; // Passing the page title
                ViewBag.Action = "EditProduct"; // Passing the method action
                return View("UpsertProduct", product);
            }
            _repository.Update(product);
            _repository.Save();
            TempData["message"] = $"{product.Name} has been edited"; // Creating temp data for view page
            return RedirectToAction("Index");
        }

        [HttpGet]
        public RedirectToActionResult DeleteProduct(long id)
        {
            var product = _repository.Get(id);
            if (product != null)
            {
                _repository.Remove(product);
                _repository.Save();
                TempData["message"] = $"{product.Name} has been removed"; // Creating temp data for view page
            }
            return RedirectToAction("Index");
        }
    }
}
