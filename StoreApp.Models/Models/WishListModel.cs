using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{
    public class WishListModel
    {
        [Key]
        public int Id { get; set; }
        public List<WishListProduct> WishListProducts { get; set; }
        public double TotalPrice { get; set; } = 0;

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUserModel ApplicationUser { get; set; }

    }
}
