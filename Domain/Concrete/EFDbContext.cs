using Domain.Entities;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("ShopDbMain") {}
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithRequired(p => p.Category);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithRequired(o => o.Product);
            
        }
        
    }
}