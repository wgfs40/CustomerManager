
using CustomerManager.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManager.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();
        Task<CustomerViewModel> GetById(int CustomerId);
        Task<CustomerViewModel> GetCustomerAddressById(int CustomerId);
        Task<bool> Register(CustomerViewModel customerViewModel);
        Task<bool> Update(CustomerViewModel customerViewModel);
        Task<bool> Remove(int CustomerId);
    }
}
