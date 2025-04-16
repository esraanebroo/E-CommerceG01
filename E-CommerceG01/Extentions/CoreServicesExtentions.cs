using Services.Abstraction;
using Servieces;
using Shared;

namespace E_CommerceG01.Extentions
{
    public static class CoreServicesExtentions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IServiceManger, ServiceManger>();
            services.AddAutoMapper(typeof(Servieces.AssemblyReference).Assembly);
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            return services;
        }
    }
}
