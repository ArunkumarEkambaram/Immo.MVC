using Immo.MVC.Day2.Models;
using Immo.MVC.Day2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//MVC5 - using System.Data.Entity;

namespace Immo.MVC.Day2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _dbContext = null;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string productName)
        {
            var products = await _dbContext.Products.Include(p => p.Category)
                .Select(p => new ProductWithCategory
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryName = p.Category.CategoryName
                }).ToListAsync();

            if (!string.IsNullOrEmpty(productName))
            {
                var searchedProducts = products.Where(p => p.ProductName.Contains(productName,StringComparison.OrdinalIgnoreCase)).ToList();
                return View(searchedProducts);
            }

            ViewBag.SearchString = productName;

            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Invalid Request");
            }
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View("GetProduct", product);
        }

        //Create Product - GET
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await Categories();
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (product == null)
            {
                return BadRequest("Inavlid Request");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = await Categories();
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            ViewBag.Categories = await Categories();
            var product = await _dbContext.Products.FindAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product not found");
            }
            if (ModelState.IsValid)
            {
                var productFromView = await _dbContext.Products.FindAsync(product.Id);
                if (productFromView != null)
                {
                    productFromView.ProductName = product.ProductName;
                    productFromView.Price = product.Price;
                    productFromView.Quantity = product.Quantity;
                    _dbContext.Update(productFromView);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Categories = await Categories();
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            else
            {
                var product = await _dbContext.Products.FindAsync(id.Value);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();

            #region Old Code

            //[NonAction]
            //public IEnumerable<Product> GetProducts()
            //{
            //    return new List<Product>
            //    {
            //        new Product { Id = 1, ProductName="Laptop", Price= 500000.5M, Quantity=100 },
            //        new () { Id = 2, ProductName="Water Bottle", Price= 850, Quantity=252 },
            //        new () { Id = 3, ProductName="Watch", Price= 7599.99M, Quantity=15 },
            //        new() { Id = 4, ProductName="Mobile Phone", Price= 19999.99M, Quantity=50 },
            //     };
            //}

            //[NonAction]
            //public ProductAndCategoryViewModel GetProductAndCategories()
            //{
            //    var products = GetProducts();
            //    var categoies = new List<Category>
            //    {
            //        new Category { Id = 1, CategoryName="Electronics" },
            //        new Category { Id = 2, CategoryName="Accessories" },
            //    };

            //    return new ProductAndCategoryViewModel
            //    {
            //        Product = products,
            //        Category = categoies,
            //    };

            //}

            #endregion
        }

        [NonAction]
        public async Task<IEnumerable<SelectListItem>> Categories()
        {
            return await _dbContext.Categories
                .Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.Id.ToString()
                }).ToListAsync();
        }
    }
}
