using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepData
{
    //TODO: Remove bool params
    public static void PrepPopulation(IApplicationBuilder app, bool isProd)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>() 
                 ?? throw new NullReferenceException("AppContext is null"), isProd);
    }

    private static void SeedData(AppDbContext context, bool isProd)
    {
        if (isProd)
        {
            Console.WriteLine("--> Attempting to apply migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not apply migrations {e.Message}");
            }
        }
        if (!context.Platforms.Any())
        {
            Console.WriteLine("----> Seeding data....");
            
            context.Platforms.AddRange(
                new Platform() { Name = ".net", Publisher = "Micro", Cost = "Free"},
                new Platform() { Name = "Sql server", Publisher = "Micro", Cost = "Free"},
                new Platform() { Name = "Kub" , Publisher = "Cloud native", Cost = "Free"}
                );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("---> Data is already exists");
        }
    }
}