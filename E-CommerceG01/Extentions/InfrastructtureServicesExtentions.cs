using Domain.Contracts;
using Presistance.Data.DataSeed;
using Presistance.Data;
using Presistance.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace E_CommerceG01.Extentions
{
    public static class InfrastructtureServicesExtentions
    {
        public static IServiceCollection AddInfrastructureServiveces(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbIntailizer, DbIntializer>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddSingleton<IConnectionMultiplexer>(services => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));
            return services;
        }
    }
}
