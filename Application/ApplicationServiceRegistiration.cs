﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration => { configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
