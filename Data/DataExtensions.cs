using Microsoft.EntityFrameworkCore;
using PizzaStore.Repositories;

namespace PizzaStore.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
        dbContext.Database.Migrate();
    }
    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
    IConfiguration configuration
    )
    {
        var connString = configuration.GetConnectionString("PizzaStoreContext");
        services.AddDbContext<PizzaStoreContext>(options => options.UseNpgsql(connString));
        services.AddScoped<IPizzasRepository, EntityFrameworkRepository>();
        return services;
    }
}