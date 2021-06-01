using ECommerceProject.DataAccess.Concrete.EntityFramework.Mapping;
using ECommerceProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.DataAccess.Concrete.Context
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=VEDAT; Database=ECommerceDb; Trusted_Connection=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductCategoryMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
