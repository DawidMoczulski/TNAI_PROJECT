using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.DataAcces.Repository
{
    public class CartRepository : Repository<CartModel>, ICartRepository
    {
        private readonly ApplicationDbContext _db;

        public CartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CartModel obj)
        {
            _db.Carts.Update(obj);
        }

        public CartModel GetOrCreateCartWithItems(string userId)
        {
            var cart = _db.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(c => c.ApplicationUserId == userId);

            if (cart == null)
            {
                cart = new CartModel
                {
                    ApplicationUserId = userId,
                    Items = new List<CartItemModel>()
                };
                _db.Carts.Add(cart);
                _db.SaveChanges();
            }

            return cart;
        }

        public void AddItemToCart(string userId, int productId, int quantity)
        {
            var cart = GetOrCreateCartWithItems(userId);

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var newItem = new CartItemModel
                {
                    ProductId = productId,
                    Quantity = quantity,
                    CartId = cart.Id
                };
                _db.CartItems.Add(newItem);
            }

            _db.SaveChanges();
        }

        public void RemoveItemFromCart(string userId, int productId)
        {
            var cart = GetOrCreateCartWithItems(userId);

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                _db.CartItems.Remove(item);
                _db.SaveChanges();
            }
        }

        public void UpdateItemQuantity(string userId, int productId, int newQuantity)
        {
            var cart = GetOrCreateCartWithItems(userId);

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                if (newQuantity <= 0)
                {
                    _db.CartItems.Remove(item);
                }
                else
                {
                    item.Quantity = newQuantity;
                }

                _db.SaveChanges();
            }
        }

        public decimal GetCartTotal(string userId)
        {
            var cart = GetOrCreateCartWithItems(userId);

            return cart.Items.Sum(i => (decimal)i.Product.Price * i.Quantity);
        }

        public void PlaceOrder(string userId)
        {
            var cart = GetOrCreateCartWithItems(userId);

            if (cart.Items == null || !cart.Items.Any())
                throw new InvalidOperationException("Cart is empty.");

            var order = new OrderModel
            {
                ApplicationUserId = userId,
                OrderDate = DateTime.Now,
                OrderProducts = new List<OrderProduct>()
            };

            foreach (var item in cart.Items)
            {
                var orderProduct = new OrderProduct
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                };
                order.OrderProducts.Add(orderProduct);
                order.TotalPrice += item.Quantity * (decimal)item.Product.Price;
            }

            _db.Orders.Add(order); //dodanie zamówienia

            _db.CartItems.RemoveRange(cart.Items); //czyszczenie koszyka
            _db.SaveChanges();
        }

    }
}
