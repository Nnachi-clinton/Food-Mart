using FoodMartModel.Enums;
using FoodMartModel.Products;

namespace FoodMartModel
{
    public class Categories
    {
        public  Category Category { get; set; }
        public string Id { get; set; }
        public string ProductId { get; set; }
        public IEnumerable<Product> Products{ get; set; }
    }
}
