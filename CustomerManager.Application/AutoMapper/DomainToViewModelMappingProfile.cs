using AutoMapper;
using CustomerManager.Application.ViewModels;
using CustomerManager.Domain.Models;

namespace CustomerManager.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Address, AddressViewModel>();
        }
        
    }
}
