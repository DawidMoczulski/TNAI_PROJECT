using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IUserRepository User { get; }
        IOrderRepository Order { get; }
        IWishListRepository WishList { get; }
        ICartRepository Cart { get; }
        ICartItemRepository CartItem { get; }
        void Save();
    }
}
