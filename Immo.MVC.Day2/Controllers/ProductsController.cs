using Immo.MVC.Day2.Models;
using Immo.MVC.Day2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Immo.MVC.Day2.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.Products = GetProducts();
            //ViewData["Products"] = GetProducts();
            //var products = GetProducts();
            var products = GetProductAndCategories();
            return View(products);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return BadRequest("Invalid Request");
            }
            var product = GetProducts().FirstOrDefault(x => x.Id == id);
            if (product == null) 
            {
                return NotFound();
            }
            return View("GetProduct",product);
        }

        [NonAction]
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, ProductName="Laptop", Price= 500000.5M, Quantity=100 },
                new () { Id = 2, ProductName="Water Bottle", Price= 850, Quantity=252 },
                new () { Id = 3, ProductName="Watch", Price= 7599.99M, Quantity=15 },
                new() { Id = 4, ProductName="Mobile Phone", Price= 19999.99M, Quantity=50 },
             };
        }

        [NonAction]
        public ProductAndCategoryViewModel GetProductAndCategories()
        {
            var products = GetProducts();
            var categoies = new List<Category>
            {
                new Category { Id = 1, CategoryName="Electronics" },
                new Category { Id = 2, CategoryName="Accessories" },
            };

            return new ProductAndCategoryViewModel
            {
                Product = products,
                Category = categoies,
            };

        }
    }
}
