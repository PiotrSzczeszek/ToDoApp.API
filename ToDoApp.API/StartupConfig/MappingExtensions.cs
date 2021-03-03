using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.API.Endpoints;

namespace ToDoApp.API.StartupConfig
{
    public static class MappingExtensions
    {
        public static void ConfigureApiMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new EndpointsMappingProfiles());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
