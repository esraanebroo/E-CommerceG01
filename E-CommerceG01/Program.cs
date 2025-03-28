
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistance.Data;
using Presistance.Data.DataSeed;
using Presistance.Repositories;
using Services.Abstraction;
using Servieces;

namespace E_CommerceG01
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(Servieces.AssemblyReference).Assembly);
            builder.Services.AddScoped<IServiceManger, ServiceManger>();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDbIntailizer, DbIntializer>();
            

            var app = builder.Build();
            await IntializeDbAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

           async Task IntializeDbAsync(WebApplication app) 
            {
                using var scope=app.Services.CreateScope();
                var dbIntializer = scope.ServiceProvider.GetRequiredService<IDbIntailizer>();
                await dbIntializer.IntializeAsync();
            }
        }
    }
}
