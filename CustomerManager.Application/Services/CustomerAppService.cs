using AutoMapper;
using CustomerManager.Application.Interfaces;
using CustomerManager.Application.ViewModels;
using CustomerManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManager.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAllCustomer());
        }

        public async Task<IEnumerable<CustomerViewModel>> CustomerSearch(string search)
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.CustomerSearch(search));
        }

        public async Task<CustomerViewModel> GetById(int CustomerId)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetCustomerByCustomerId(CustomerId));
        }

        public async Task<CustomerViewModel> GetCustomerAddressById(int CustomerId)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetCustomerAddressByCustomerId(CustomerId));
        }

        public async Task<bool> Register(CustomerViewModel customerViewModel)
        {
            var customer = _mapper.Map<Domain.Models.Customer>(customerViewModel);
            _customerRepository.AddCustomer(customer);
            var success = await _customerRepository.Save();
            return success;
        }

        public async Task<bool> Remove(int CustomerId)
        {
            var customerAddress = await _customerRepository.GetCustomerAddressByCustomerId(CustomerId);            
            _customerRepository.DeleteCustomer(customerAddress);
            var success = await _customerRepository.Save();
            return success;
        }

        public async Task<bool> Update(CustomerViewModel customerViewModel)
        {
            var customer = _mapper.Map<Domain.Models.Customer>(customerViewModel);
            _customerRepository.UpdateCustomer(customer);
            var success = await _customerRepository.Save();
            return success;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

       
    }
}
