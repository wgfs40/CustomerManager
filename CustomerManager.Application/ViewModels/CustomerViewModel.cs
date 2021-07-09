using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerManager.Application.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El apellido del cliente es obligatorio")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El telefono del cliente es obligatorio")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El telefono no es valido")]
        public string PhoneNumber { get; set; }

        public List<AddressViewModel> Addresses { get; set; }
    }
}
