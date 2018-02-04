using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete.Repositories
{
    public class OrdersRepository : IRepository<Order>
    {
        private readonly EFDbContext _context = new EFDbContext();
        public IEnumerable<Order> All => _context.Orders;
    }
}