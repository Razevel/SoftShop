using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete.Repositories
{
    public class ProductsRepository : IRepository<Product>
    {
        private readonly EFDbContext _context = new EFDbContext();
        public IEnumerable<Product> All => _context.Products;
    }
}