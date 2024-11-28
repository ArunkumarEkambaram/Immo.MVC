using Immo.MVC.Day2.Models;

namespace Immo.MVC.Day2.ViewModels
{
    public class ProductAndCategoryViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}
