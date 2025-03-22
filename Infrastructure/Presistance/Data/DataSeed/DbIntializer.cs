using Domain.Contracts;
using System.Text.Json;

namespace Presistance.Data.DataSeed
{
    public class DbIntializer : IDbIntailizer
    {
        private readonly AppDbContext _dbContext;

        public DbIntializer(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task IntializeAsync()
        {
            try 
            {
                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    await _dbContext.Database.MigrateAsync();
                    if (!_dbContext.ProductTypes.Any())
                    {
                        //C:\Users\user\source\repos\E-CommerceG01\Infrastructure\Presistance\Data\DataSeed\types.json
                        var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\DataSeed\types.json");
                        var types=JsonSerializer.Deserialize<List<ProductType>>(typesData);
                        if (types is not null && types.Any())
                        {
                            await _dbContext.AddRangeAsync(types);
                            await _dbContext.SaveChangesAsync();
                        }
                    }

                    if (!_dbContext.ProductBrands.Any())
                    {
                        //C:\Users\user\source\repos\E-CommerceG01\Infrastructure\Presistance\Data\DataSeed\brands.json
                        var brandData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\DataSeed\brands.json");
                        var brand = JsonSerializer.Deserialize<List<ProductType>>(brandData);
                        if (brand is not null && brand.Any())
                        {
                            await _dbContext.AddRangeAsync(brand);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                    if (!_dbContext.Products.Any())
                    {
                        //C:\Users\user\source\repos\E-CommerceG01\Infrastructure\Presistance\Data\DataSeed\product.json
                        var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\DataSeed\products.json");
                        var product = JsonSerializer.Deserialize<List<ProductType>>(productsData);
                        if (product is not null && product.Any())
                        {
                            await _dbContext.AddRangeAsync(product);
                            await _dbContext.SaveChangesAsync();
                        }
                    }


                }


            }
            catch { }

        }
    }
}
