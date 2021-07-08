using System;

namespace CustomerManager.Application.ViewModels
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; }
        public string NumberAparment { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
