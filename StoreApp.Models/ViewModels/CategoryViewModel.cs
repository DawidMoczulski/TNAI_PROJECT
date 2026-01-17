using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.ViewModels
{
    public class CategoryViewModel
    {
        [ValidateNever]
        public IEnumerable<CategoryModel> CategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<ProductModel> ProductModels { get; set; }
    }
}
