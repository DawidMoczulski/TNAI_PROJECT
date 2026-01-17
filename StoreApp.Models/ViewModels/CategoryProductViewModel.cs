using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.ViewModels
{
    public class CategoryProductViewModel
    {
        public CategoryModel Category { get; set; }
        public IEnumerable<ProductModel> ProductModels { get; set; }
    }
}
