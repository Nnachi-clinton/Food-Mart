using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMartDomain.ViewModels.ResponseModel
{
    public class CategoryResponseViewModel
    {
        public string CategoryName { get; set; }
        public string Id { get; set; }
        public IEnumerable<ProductResponseViewModel> Products { get; set; }
    }
}
