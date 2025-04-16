using E_CommerceG01.Extentions;

namespace E_CommerceG01
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Services
            //Presnetation Services
            builder.Services.AddPresentationServices();
            //Core Services
            builder.Services.AddCoreServices();
            //Infrastructure services
            builder.Services.AddInfrastructureServiveces(builder.Configuration);

            var app = builder.Build();
            app.UseCustomMiddleware();
            await app.SeedDbAsync();
            #endregion

            #region pipeline.
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

            //builder.Services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.InvalidModelStateResponseFactory = ApiResponseFactory.CustomValidtionErrorResponse;
            //});



            // app.UseMiddleware<GlobalErrorHandlingMiddleware>();

            #endregion
        }
    }
}
