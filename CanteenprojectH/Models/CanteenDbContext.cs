using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CanteenprojectH.Models
{
    public class CanteenDbContext : DbContext
    {
        public CanteenDbContext(DbContextOptions<CanteenDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<MonthlyReport> MonthlyReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }

}
