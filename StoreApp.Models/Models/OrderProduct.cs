using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{
    //klasa pośrednicząca dla zamówienia
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }
        public OrderModel Order { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public double Price { get; set; }  //cena w momencie zamówienia

        public int Quantity { get; set; }
    }
}
