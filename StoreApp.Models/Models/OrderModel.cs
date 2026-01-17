using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{
    //zamówienie, ma listę produktów, cenę całkowitą, status, powiązanego użytkownika

    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        public decimal TotalPrice { get; set; } = 0;

        public string State { get; set; } = "Pending";
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUserModel ApplicationUser { get; set; }
    }
}
