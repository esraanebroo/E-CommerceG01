
using Domain.Contracts;
using E_CommerceG01.Extentions;
using E_CommerceG01.Factories;
using E_CommerceG01.Middlewares;
using Microsoft.AspNetCore.Mvc;
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

            //Presnetation Services
            builder.Services.AddPresentationServices();
            //Core Services
            builder.Services.AddCoreServices();
            //Infrastructure services
            builder.Services.AddInfrastructureServiveces(builder.Configuration);

            var app = builder.Build();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.CustomValidtionErrorResponse;
            });
            

           
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            await app.SeedDbAsync();

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

           
        }
    }
}
