
using Microsoft.EntityFrameworkCore;
using Mvm.Core.Domain.Customers.Entities;


namespace Mvm.Infrastructures.Data.SqlServer
{
    public class MvmDbContext:DbContext
    {
        public MvmDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }

    }
}
