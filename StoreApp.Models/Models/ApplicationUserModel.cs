using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models.Models
{
    //rozszerza IdentityUser czyli domyślną klasę użytkownika z ASP.NET Identity (obsługa logowania, hasła itd.)
    //ta klasa będzie powiązana z tabelą użytkowników
    //ApplicationUserModel jeden-do-wielu OrderModel
    //ApplicationUserModel jeden-do-jednego WishListModel

    public class ApplicationUserModel : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public ICollection<OrderModel> Orders { get; set; }
        public WishListModel WishList { get; set; }
    }

}
