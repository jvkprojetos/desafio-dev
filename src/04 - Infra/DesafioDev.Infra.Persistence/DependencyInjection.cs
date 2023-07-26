using DesafioDev.Domain.Repositories;
using DesafioDev.Infra.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioDev.Infra.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IEstablishmentRepository, EstablishmentRepository>();
        return services;
    }

    public static void RunMigration(this IApplicationBuilder app)
    {
        using var provider = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = provider.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}
