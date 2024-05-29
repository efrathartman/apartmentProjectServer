using Microsoft.Extensions.DependencyInjection;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Response>, ResponseRepository>();
            services.AddScoped<IRepository<Apartment>, ApartmentRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            return services;
        }
    }
}
