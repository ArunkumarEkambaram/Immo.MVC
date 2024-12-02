using Immo.MVC.Day2.Models;
using Immo.MVC.Day2.Repository;
using Immo.MVC.Day2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Immo.MVC.Day2.Controllers
{
    public class ProductsEFController : Controller
    {
        private readonly IRepositoryWithCategory<Product> _repos = null;

        public ProductsEFController(IRepositoryWithCategory<Product> repos)
        {
            _repos = repos;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _repos.GetAll();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            AddProductViewModel vm = new()
            {
                Categories = await _repos.Categories()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _repos.Add(product);

            AddProductViewModel vm = new()
            {
                Categories = await _repos.Categories()
            };
            if (!ModelState.IsValid || result == null)
                return View(vm);

            return RedirectToAction(nameof(Index));
        }
    }
}
