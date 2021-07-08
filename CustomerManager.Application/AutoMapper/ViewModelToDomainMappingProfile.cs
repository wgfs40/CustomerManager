using AutoMapper;
using CustomerManager.Application.ViewModels;
using CustomerManager.Domain.Models;

namespace CustomerManager.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<AddressViewModel, Address>();
        }
    }
}
