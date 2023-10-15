using FoodMartModel.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMartModel.Products
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal  Price { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public string ProductId { get; set; }
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public Categories Category { get; set; }

        [ForeignKey("Analysis")]
        public string AnalysisId { get; set; }
        public Analysis Analysis { get; set; }



    }
}
