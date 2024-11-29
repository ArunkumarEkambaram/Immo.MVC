using System.Runtime.Serialization;

namespace Immo.MVC.Day2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        //One to Many
      //  [IgnoreDataMember]
      //  public List<Product> Products { get; set; }
    }
}
