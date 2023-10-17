using FoodMartModel.Enums;


namespace FoodMartDomain.ViewModels.RequestModel
{
    public class ProductRequestViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public string CategoryId { get; set; }
        public string AnalysisId { get; set; }
    }
}
