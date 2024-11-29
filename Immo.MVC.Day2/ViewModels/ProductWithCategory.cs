namespace Immo.MVC.Day2.ViewModels
{
    public class ProductWithCategory
    {
        public int Id { get; set; }     
        
        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.Now;

        public string CategoryName { get; set; }
    }
}
