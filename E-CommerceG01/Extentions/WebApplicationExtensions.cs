using Domain.Contracts;
using E_CommerceG01.Middlewares;

namespace E_CommerceG01.Extentions
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> SeedDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbIntializer = scope.ServiceProvider.GetRequiredService<IDbIntailizer>();
            await dbIntializer.IntializeAsync();
            return app;
        }
        public static WebApplication UseCustomMiddleware(this WebApplication app) 
        {
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return app;
        }

    }
}
