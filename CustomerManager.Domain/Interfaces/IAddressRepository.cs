using CustomerManager.Domain.Models;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Interfaces
{
    public interface IAddressRepository
    {
        void DeleteAddress(Address address);
        Task<bool> Save();
    }
}
