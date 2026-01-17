using Microsoft.EntityFrameworkCore;
using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.Models;
using System.Linq;

namespace StoreApp.DataAcces.Repository
{
    public class WishListRepository : Repository<WishListModel>, IWishListRepository
    {
        private readonly ApplicationDbContext _db;
        public WishListRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WishListModel wishList)
        {
            _db.WishList.Update(wishList);
        }

        public WishListModel GetOrCreateWishListWithItems(string userId)
        {
            var wishList = _db.WishList
                .Include(w => w.WishListProducts)
                .ThenInclude(wp => wp.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefault(w => w.ApplicationUserId == userId);

            if (wishList == null)
            {
                wishList = new WishListModel
                {
                    ApplicationUserId = userId,
                    WishListProducts = new List<WishListProduct>()
                };
                _db.WishList.Add(wishList);
                _db.SaveChanges();
            }

            return wishList;
        }

        public void AddItemToWishList(string userId, int productId, int quantity = 1)
        {
            var wishList = GetOrCreateWishListWithItems(userId);

            var existingItem = wishList.WishListProducts
                .FirstOrDefault(wp => wp.ProductId == productId);

            if (existingItem == null)
            {
                wishList.WishListProducts.Add(new WishListProduct
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            else
            {
                existingItem.Quantity += quantity;
            }

            _db.SaveChanges();
        }

        public void RemoveItemFromWishList(string userId, int productId)
        {
            var wishList = GetOrCreateWishListWithItems(userId);

            var item = wishList.WishListProducts
                .FirstOrDefault(wp => wp.ProductId == productId);

            if (item != null)
            {
                wishList.WishListProducts.Remove(item);
                _db.SaveChanges();
            }
        }

        public double GetWishListTotal(string userId)
        {
            var wishList = GetOrCreateWishListWithItems(userId);
            return wishList.WishListProducts.Sum(wp => wp.Product.Price * wp.Quantity);
        }
    }
}