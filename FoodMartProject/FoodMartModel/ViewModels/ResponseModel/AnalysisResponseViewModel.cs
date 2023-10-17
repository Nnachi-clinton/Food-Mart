namespace FoodMartDomain.ViewModels.ResponseModel
{
    public class AnalysisResponseViewModel
    {
        public string AnalysisId { get; set; }
        public long ViewCount { get; set; }
        public long SellingCount { get; set; }
        public string ProductId { get; set; }
        public ProductResponseViewModel Product { get; set; }
    }
}
