
using AutoMapper;
using CustomerManager.Application.Interfaces;
using CustomerManager.Domain.Interfaces;
using System.Threading.Tasks;

namespace CustomerManager.Application.Services
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public AddressAppService(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }
        public async Task<bool> Remove(int AddressId)
        {
            _addressRepository.DeleteAddress(new Domain.Models.Address { AddressId = AddressId });
            var result = await _addressRepository.Save();
            return result;
        }
    }
}
