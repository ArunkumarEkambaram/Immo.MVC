using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Immo.MVC.Day2.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter Product Name")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public decimal? Price { get; set; }

        [Required]
        public int? Quantity { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.Now;

        //Reference
        public Category Category { get; set; }

        //FK        
        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
    }
}
