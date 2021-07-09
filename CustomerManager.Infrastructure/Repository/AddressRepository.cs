using CustomerManager.Domain.Interfaces;
using CustomerManager.Domain.Models;
using CustomerManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerManager.Infrastructure.Repository
{
    public class AddressRepository : IAddressRepository
    {
        protected readonly CustomerManagerContext Db;
        protected readonly DbSet<Address> DbSet;

        public AddressRepository(CustomerManagerContext context)
        {
            Db = context;
            DbSet = Db.Set<Address>();
        }

        public void DeleteAddress(Address address)
        {
            DbSet.Remove(address);
        }

        public async Task<bool> Save()
        {
            return await Db.Commit();
        }
    }
}
