using CustomerManager.Application.Interfaces;
using CustomerManager.Application.Services;
using CustomerManager.Domain.Interfaces;
using CustomerManager.Infrastructure.Context;
using CustomerManager.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManager.Infrastructure.IoC
{
    public static class NativeInjectorIoC
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //app services            
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            var strConn = configuration.GetConnectionString("default");
            services.AddDbContext<CustomerManagerContext>(opt => opt.UseSqlServer(strConn));
        }
    }
}
