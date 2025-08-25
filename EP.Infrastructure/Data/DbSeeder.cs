using EP.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EP.Infrastructure.Data;


public static class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        if (!await roleManager.RoleExistsAsync("Member"))
        {
            await roleManager.CreateAsync(new IdentityRole("Member"));
        }

        if (!await roleManager.RoleExistsAsync("Administrator"))
        {
            await roleManager.CreateAsync(new IdentityRole("Administrator"));
        }

        var adminUser = await userManager.FindByNameAsync("admin");
        if (adminUser == null)
        {
            adminUser = new User
            {
                FirstName = "Arian",
                LastName = "Esmaeili",
                UserName = "admin",
                Email = "admin@test.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "Admin@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Administrator");
            }
        }

        var normalUser = await userManager.FindByNameAsync("testUser");

        if (normalUser == null)
        {
            normalUser = new User
            {
                FirstName = "Arian",
                LastName = "Esmaeili",
                UserName = "test",
                Email = "test@test.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(normalUser, "Test1234");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "Member");
            }
        }
    }
}

