using DKW.Abp.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class MigrationExtensions
{
    public static async Task MigrateAsync(this IHost host, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(host);

        await host.Services.MigrateAsync(cancellationToken);
    }

    public static async Task MigrateAsync(this IServiceProvider serviceProvider, CancellationToken cancellationToken = default)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            await scope.MigrateAsync(cancellationToken);
        }
    }

    public static async Task MigrateAsync(this IServiceScope scope, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(scope);

        var migrationService = scope.ServiceProvider.GetRequiredService<DbContextMigrationManager>();

        await migrationService.MigrateAsync(cancellationToken);
    }

    public static IServiceCollection AddDkwMigrations(this IServiceCollection services, Action<DkwDbContextMigrationOptions>? configure = null)
    {
        return services
            .Configure<DkwDbContextMigrationOptions>(options => configure?.Invoke(options))
            .AddScoped<DbContextMigrationManager>();
    }
}