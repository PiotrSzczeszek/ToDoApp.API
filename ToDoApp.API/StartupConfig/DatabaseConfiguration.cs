using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoApp.API.StartupConfig
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureAppDatabase(this IServiceCollection services, IConfiguration config)
        {
            
            services.AddDbContext<ToDoAppContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Default")));
            
        }

    }
}
