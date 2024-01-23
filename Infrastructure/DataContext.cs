using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {   }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
