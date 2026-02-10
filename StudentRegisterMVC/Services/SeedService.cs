using Microsoft.AspNetCore.Identity;
using StudentRegisterMVC.Data;
using StudentRegisterMVC.Models;

namespace StudentRegisterMVC.Services;

public class SeedService
{
    
    public static async Task SeedDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

        try
        {
            //ensure the database is ready
            logger.LogInformation("Ensuring the database is created.");
            await context.Database.EnsureCreatedAsync();

            // add roles
            logger.LogInformation("Seeding roles");
            await AddRoleAsync(roleManager, "Admin");
            await AddRoleAsync(roleManager, "Teacher");
            await AddRoleAsync(roleManager, "Student");

            // seed admin data
            logger.LogInformation("Seeding admin user");
            var adminEmail = "admin@admin.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    NormalizedUserName = adminEmail.ToUpper(),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123#");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                   
                }
            }
        }
        catch (Exception ex) 
        {
           logger.LogError(ex, "An error occured while seeding the database");

        }
    }

    private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            var result = await roleManager.CreateAsync(new IdentityRole(roleName));
            if (!result.Succeeded) 
            {
                throw new Exception($"Failed to create role {roleName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}
