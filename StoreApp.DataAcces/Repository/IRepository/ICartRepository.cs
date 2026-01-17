using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Models.Models;

namespace StoreApp.DataAcces.Repository.IRepository
{
    public interface ICartRepository : IRepository<CartModel>
    {
        void Update(CartModel obj);
        CartModel GetOrCreateCartWithItems(string userId);
        void AddItemToCart(string userId, int productId, int quantity);
        void RemoveItemFromCart(string userId, int productId);
        void UpdateItemQuantity(string userId, int productId, int newQuantity);
        decimal GetCartTotal(string userId);
        void PlaceOrder(string userId);
    }
}
