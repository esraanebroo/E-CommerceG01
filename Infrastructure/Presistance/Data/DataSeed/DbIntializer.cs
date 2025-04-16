using Domain.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Presistance.Data.DataSeed
{
    public class DbIntializer : IDbIntailizer
    {
        private readonly AppDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public DbIntializer(AppDbContext dbContext, RoleManager<IdentityRole> roleManager , UserManager<User> userManager )
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
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

        public async Task IntializeIdentityAsync()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }
            if(!_userManager.Users.Any())
            {
                var adminUser = new User()
                {
                    DisplayName = "Admin",
                    UserName = "Admin",
                    Email = "Admin@gmail.com",
                    PhoneNumber = "01013145678"
                };
                var superAdminUser = new User()
                {
                    DisplayName = "SuperAdmin",
                    UserName = "SuperAdmin",
                    Email = "superAdmin@gmail.com",
                    PhoneNumber = "01013145678"
                };
                await _userManager.CreateAsync(adminUser,"P@ssw0rd");
                await _userManager.CreateAsync(superAdminUser,"Passw0rd@");
                await _userManager.AddToRoleAsync(adminUser, "Admin");
                await _userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");

            }
        }
    }
}
