using StoreApp.Models.Models;

namespace StoreApp.DataAcces.Repository.IRepository
{
    public interface IWishListRepository : IRepository<WishListModel>
    {
        void Update(WishListModel wishList);

        WishListModel GetOrCreateWishListWithItems(string userId);
        void AddItemToWishList(string userId, int productId, int quantity = 1);
        void RemoveItemFromWishList(string userId, int productId);
        double GetWishListTotal(string userId);
    }
}