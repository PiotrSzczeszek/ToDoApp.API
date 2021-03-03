using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Core.Services;
using ToDoApp.Data.Entities;
using ToDoApp.Infrastracture.Services;

namespace ToDoApp.API.StartupConfig
{
    public static class ServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));

            services.AddTransient<IBCryptService, BCryptService>();
            services.AddTransient<IRegistrationService, RegistrationService>();
        }
    }
}
