using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }

        public List<CartItemModel> Items { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUserModel ApplicationUser { get; set; }

        public double TotalPrice { get; set; } = 0;
    }
}
