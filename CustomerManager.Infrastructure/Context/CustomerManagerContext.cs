
using CustomerManager.Domain.Models;
using CustomerManager.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerManager.Infrastructure.Context
{
    public class CustomerManagerContext : DbContext
    {
        public CustomerManagerContext(DbContextOptions<CustomerManagerContext> options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new AddressMap());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}
