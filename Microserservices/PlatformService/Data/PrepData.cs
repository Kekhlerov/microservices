using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepData
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>() 
                 ?? throw new NullReferenceException("AppContext is null"));
    }

    private static void SeedData(AppDbContext context)
    {
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