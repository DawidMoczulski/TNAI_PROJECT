using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models;
using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.DataAcces.Repository
{
    public class OrderRepository : Repository<OrderModel>, IOrderRepository
    {
        private ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderModel Order)
        {
            _db.Orders.Update(Order);
        }

        public IEnumerable<OrderModel> GetOrdersByUser(string userId)
        {
            return _db.Orders
                .Where(o => o.ApplicationUserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        public IEnumerable<OrderModel> GetAllOrdersWithProducts()
        {
            return _db.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Include(o => o.ApplicationUser)
                .ToList();
        }

        public OrderModel? GetOrderWithProducts(int orderId)
        {
            return _db.Orders
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .Include(o => o.ApplicationUser)
                .FirstOrDefault(o => o.Id == orderId);
        }
    }
}
