using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.Models;

namespace StoreApp.DataAcces.Repository
{
    public class CartItemRepository : Repository<CartItemModel>, ICartItemRepository
    {
        private readonly ApplicationDbContext _db;

        public CartItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CartItemModel obj)
        {
            _db.CartItems.Update(obj);
        }

        public IEnumerable<CartItemModel> GetItemsByCartId(int cartId)
        {
            return _db.CartItems.Where(i => i.CartId == cartId).ToList();
        }
    }
}
