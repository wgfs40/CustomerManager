using System.Threading.Tasks;

namespace CustomerManager.Application.Interfaces
{
    public interface IAddressAppService
    {
        Task<bool> Remove(int AddressId);
    }
}
