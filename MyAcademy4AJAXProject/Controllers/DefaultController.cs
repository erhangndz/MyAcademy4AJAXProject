using Microsoft.AspNetCore.Mvc;
using MyAcademy4AJAXProject.DataAccess.Context;
using MyAcademy4AJAXProject.DataAccess.Entities;
using Newtonsoft.Json;

namespace MyAcademy4AJAXProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly AjaxContext _context;

        public DefaultController(AjaxContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            var products = JsonConvert.SerializeObject(values);
            return Json(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            var values = JsonConvert.SerializeObject(product);
            return Json(values);
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return NoContent();
        }

        public IActionResult GetProductById(int id)
        {
            var value = _context.Products.Find(id);
            var product = JsonConvert.SerializeObject(value);
            return Json(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
