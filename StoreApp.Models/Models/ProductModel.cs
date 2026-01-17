using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StoreApp.Models.Models
{
    //reprezentuje produkt, powiązany z CategoryId, opcjonalnie może mieć swój obrazek
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        [Display(Name ="Price")]
        [Range(1, 10000)]
        public double Price { get; set; }  

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]

        public CategoryModel? Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
