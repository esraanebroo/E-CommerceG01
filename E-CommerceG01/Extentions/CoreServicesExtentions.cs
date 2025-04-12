using Services.Abstraction;
using Servieces;

namespace E_CommerceG01.Extentions
{
    public static class CoreServicesExtentions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services) 
        {
            services.AddScoped<IServiceManger, ServiceManger>();
            services.AddAutoMapper(typeof(Servieces.AssemblyReference).Assembly);
            return services;
        }
    }
}
