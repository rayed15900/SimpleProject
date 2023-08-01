using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.DependencyExtension
{
    public static class DependencyInjectionResolver
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleProjectContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            // UnitOfWork
            services.AddScoped<IUOW, UOW>();

            // Services
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
