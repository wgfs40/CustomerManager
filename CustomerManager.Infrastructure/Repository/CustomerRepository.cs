using CustomerManager.Domain.Interfaces;
using CustomerManager.Domain.Models;
using CustomerManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManager.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly CustomerManagerContext Db;
        protected readonly DbSet<Customer> DbSet;

        public CustomerRepository(CustomerManagerContext context)
        {
            Db = context;
            DbSet = Db.Set<Customer>();
        }
        public void AddCustomer(Customer customer)
        {
            DbSet.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            DbSet.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Customer> GetCustomerByCustomerId(int CustomerId)
        {
            return await DbSet.FindAsync(CustomerId);
        }

        public async Task<Customer> GetCustomerAddressByCustomerId(int CustomerId)
        {            
            return await DbSet.Where(c => c.CustomerId ==  CustomerId).Include(c => c.Addresses).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Customer>> CustomerSearch(string search)
        {
            return await DbSet.Where(c => c.FirstName.Contains(search) || c.LastName.Contains(search)).ToListAsync();
        }


        public void UpdateCustomer(Customer customer)
        {
            DbSet.Update(customer);
        }

        public async Task<bool> Save()
        {
            return await Db.Commit();
        }
    }
}
