using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMartModel.Products
{
    public class Analysis
    {
        public string AnalysisId { get; set; }
        public long ViewCount { get; set; }
        public long SellingCount { get; set; }


        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public Product Product { get; set; }

    }
}
