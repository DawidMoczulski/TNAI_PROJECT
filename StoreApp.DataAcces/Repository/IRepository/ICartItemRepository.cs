using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.Models.Models;

namespace StoreApp.DataAcces.Repository.IRepository
{
    public interface ICartItemRepository : IRepository<CartItemModel>
    {
        void Update(CartItemModel obj);
        IEnumerable<CartItemModel> GetItemsByCartId(int cartId);
    }
}
