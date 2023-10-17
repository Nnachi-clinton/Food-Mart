using FoodMartModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMartDomain.ViewModels.ResponseModel
{
    public class ProductResponseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public string AnalysisId { get; set; }
        public CategoryResponseViewModel Category { get; set; } 
        public AnalysisResponseViewModel Analysis { get; set; } 
    }
}
