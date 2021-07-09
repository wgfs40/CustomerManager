using CustomerManager.Application.Interfaces;
using CustomerManager.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManager.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IAddressAppService _addressAppService;

        public CustomerController(ICustomerAppService customerAppService, IAddressAppService addressAppService)
        {
            _customerAppService = customerAppService;
            _addressAppService = addressAppService;
        }

        public async Task<IActionResult> Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                var result = await _customerAppService.GetAll();
                return View(result);
            }
            else
            {
                var result = await _customerAppService.CustomerSearch(search);
                return View(result);
            }
           
        }

        public IActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(CustomerViewModel customerViewModel)
        {
           var resul = await _customerAppService.Register(customerViewModel);
            if (resul)
            {
                return Json(new { message = "Cliente resgitrado con exito." });
            }
            else
            {
                return Json(new { message = "Al ha pasado." });
            }
            
        }

        public async Task<IActionResult> UpdateCustomer(int customerId)
        {
            var customer = await _customerAppService.GetCustomerAddressById(customerId);

            return View(customer);
        }

        [HttpPost]
        public async Task <IActionResult> UpdateCustomer(CustomerViewModel customerViewModel)
        {
            var result = await _customerAppService.Update(customerViewModel);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View(customerViewModel);
        }

        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var customer = await _customerAppService.GetById(customerId);
            
            return View(customer);
        }

        [HttpPost, ActionName("DeleteCustomer")]       
        public async Task<IActionResult> DeleteConfirmed(int customerId)
        {
            var customer = await _customerAppService.Remove(customerId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            var result = await _addressAppService.Remove(addressId);
            if (result)
            {
                return Json(new { message = "Direccion eleminada correctamente."});
            }
            else
            {
                return Json(new { message = "Ha pasado algo, favor de revisar." });
            }
            
        }
    }
}
