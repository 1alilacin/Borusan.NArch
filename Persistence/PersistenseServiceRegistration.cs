using Application.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.Abstract;
using Persistence.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenseServiceRegistration
    {
        public static IServiceCollection AddPersitenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BorusanDbContext>();
            services.AddScoped<IBrandRepository, EfBrandRepository>();
            services.AddScoped<IColorRepository, EfColorRepository>();
            services.AddScoped<IFuelRepository, EfFuelRepository>();
            services.AddScoped<ICarRepository, EfCarRepository>();
            services.AddScoped<IModelRepository, EfModelRepository>();
            services.AddScoped<ITransmissionRepository, EfTransmissionRepository>();
            return services;
        }
    }
}
