using System;

namespace CustomerManager.Domain.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; }
        public string NumberAparment { get; set; }
        public DateTime CreateDate { get; set; }


        public Customer Customer { get; set; }
    }
}
