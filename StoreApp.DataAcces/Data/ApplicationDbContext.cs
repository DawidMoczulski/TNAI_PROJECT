using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.Models.Models;

namespace StoreApp.DataAcces.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserModel, IdentityRole, string>
    {
        //public class ApplicationDbContext : IdentityDbContext<IdentityUser>

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        //public DbSet<ApplicationUserModel> ApplicationUser { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<WishListModel> WishList { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<CartItemModel> CartItems { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<WishListProduct> WishListProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUserModel>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.ApplicationUser)
            .HasForeignKey(o => o.ApplicationUserId);

            modelBuilder.Entity<ApplicationUserModel>()
            .HasOne(u => u.WishList)
            .WithOne(w => w.ApplicationUser)
            .HasForeignKey<WishListModel>(w => w.ApplicationUserId);

            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Mochi", DisplayOrder = 1 },
                new CategoryModel { Id = 2, Name = "Konpeito", DisplayOrder = 2 },
                new CategoryModel { Id = 3, Name = "Dango", DisplayOrder = 3 }
            );

            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { Id = 1, Name = "Mochi Cookies & Cream",Description="Przepyszne Mochi o smaku ciasteczkowym", Price = 20.99, CategoryId = 1, ImageUrl= "images/MOCHI1.png" },
                new ProductModel { Id = 2, Name = "Mochi Matcha",Description="Mochi o smaku orzeźwiającej matchy", Price = 20.99, CategoryId = 1, ImageUrl= "images/MOCHI2.png" },
                new ProductModel { Id = 3, Name = "Mochi Coconut",Description="Mochi o smaku kokosowym", Price = 20.99, CategoryId = 1, ImageUrl= "images/MOCHI3.png" },
                new ProductModel { Id = 4, Name = "Owocowe Kasugai", Description = "Cukierki o smaku owocowym", Price = 14.99, CategoryId = 2, ImageUrl = "images/Konpeito1.png" },
                new ProductModel { Id = 5, Name = "Konpeito Kittens", Description = "", Price = 18.99, CategoryId = 2, ImageUrl = "images/Konpeito2.png" },
                new ProductModel { Id = 6, Name = "Konpeito Naruto", Description = "", Price = 16.99, CategoryId = 2, ImageUrl = "images/Konpeito3.png" },
                new ProductModel { Id = 7, Name = "Spring Dango", Description = "", Price = 9.99, CategoryId = 3, ImageUrl = "images/Dango1.png" },
                new ProductModel { Id = 8, Name = "Peach Dango", Description = "", Price = 10.99, CategoryId = 3, ImageUrl = "images/Dango2.png" },
                new ProductModel { Id = 9, Name = "Cola Dango", Description = "", Price = 9.99, CategoryId = 3, ImageUrl = "images/Dango3.png" }
            );

            modelBuilder.Entity<OrderModel>()
                .Property(o => o.TotalPrice)
                .HasPrecision(18, 2); //18 cyfr całkowitych, 2 po przecinku
        }
    }
}
