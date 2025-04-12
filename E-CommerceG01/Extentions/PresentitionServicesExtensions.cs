using E_CommerceG01.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceG01.Extentions
{
    public static class PresentitionServicesExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services) 
        {
            services.AddControllers()/*.AddApplicationPart(typeof(Presentation.AssemblyReference).*/);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.CustomValidtionErrorResponse;
            });
            return services;
        }
    }
}
