using System.Collections.Generic;

namespace CustomerManager.Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
