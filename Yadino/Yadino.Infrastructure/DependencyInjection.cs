using Microsoft.EntityFrameworkCore;
using Yadino.Application.Common.Interfaces;
using Yadino.Infrastructure.Persistence;

namespace Yadino.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Yadino")
                               ?? throw new InvalidOperationException("Connection string 'Database' is not configured.");

        services.AddDbContext<YadinoDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IYadinoDbContext>(sp =>
            sp.GetRequiredService<YadinoDbContext>());

        return services;
    }
}