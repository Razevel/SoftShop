using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete.Repositories
{
    public class CategoriesRepository : IRepository<Category>
    {
        private readonly EFDbContext _context = new EFDbContext();
        public IEnumerable<Category> All => _context.Categories;
    }
}