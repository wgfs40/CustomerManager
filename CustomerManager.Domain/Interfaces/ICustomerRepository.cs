
using CustomerManager.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerByCustomerId(int CustomerId);
        Task<Customer> GetCustomerAddressByCustomerId(int CustomerId);
        Task<bool> Save();
    }
}
