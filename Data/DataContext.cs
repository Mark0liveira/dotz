using Microsoft.EntityFrameworkCore;
using Dotz.Models;

namespace Dotz.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddress { get; set; }
        public DbSet<Extract> Extract { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}