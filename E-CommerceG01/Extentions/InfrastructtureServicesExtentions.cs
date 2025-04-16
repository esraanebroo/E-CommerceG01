using Domain.Contracts;
using Presistance.Data.DataSeed;
using Presistance.Data;
using Presistance.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Presistance.Identity;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            services.AddDbContext<IdentityAppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });

            services.AddIdentity<User,IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<IdentityAppDbContext>();

           // services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<IdentityAppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbIntailizer, DbIntializer>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddSingleton<IConnectionMultiplexer>(services => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));
            services.ConfigureJwt(configuration);
            return services;
        }
        public static IServiceCollection ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                };
            });
        services.AddAuthorization();
            return services;
        }
    
    
    
    
    }
}
