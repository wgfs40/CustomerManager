using System.Collections.Generic;

namespace CustomerManager.Application.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public List<AddressViewModel> Addresses { get; set; }
    }
}
