using Domain.Contracts;

namespace E_CommerceG01.Extentions
{
    public static class WebApplicationExtensions
    {
        public static async Task SeedDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbIntializer = scope.ServiceProvider.GetRequiredService<IDbIntailizer>();
            await dbIntializer.IntializeAsync();
        }

    }
}
