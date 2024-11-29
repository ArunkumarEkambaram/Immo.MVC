using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Immo.MVC.Day2.ViewModels
{
    public class AddProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product cannot be blank")]
        public string ProductName { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
