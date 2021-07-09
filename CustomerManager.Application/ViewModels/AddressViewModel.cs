using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerManager.Application.ViewModels
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "la calle o direccion es obligatoria")]
        public string Street { get; set; }
        [Required(ErrorMessage = "el numero de la casa o aparatamento es obligatorio")]
        public string NumberAparment { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
