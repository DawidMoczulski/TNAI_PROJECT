using StoreApp.Models;
using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository.IRepository
{
    public interface IOrderRepository : IRepository<OrderModel>
    {
        void Update(OrderModel product);
        IEnumerable<OrderModel> GetAllOrdersWithProducts();
        OrderModel? GetOrderWithProducts(int orderId);
        IEnumerable<OrderModel> GetOrdersByUser(string userId);
    }
}
