using FoodMartModel.Enums;
using FoodMartModel.Products;

namespace FoodMartModel
{
    public class Categories
    {
        public string CategoryName { get; set; }
        public string Id { get; set; }
        public string ProductId { get; set; }
        public IEnumerable<Product> Products{ get; set; }

    }
}
