using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Infrastructure;
using WebAPI.Interfaces;
using WebAPI.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));


            services.AddScoped<IMapper, AutoMapperMapper>();

            services.AddScoped<IProductsRepository, InMemoryProductsRepository>();
        }
    }
}
