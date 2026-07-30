using Catalog.API.Services;
using Microsoft.Azure.Cosmos;

namespace Catalog.API.Extensions;

public static class CosmosDbExtensions
{
    public static IServiceCollection AddCosmosDbServices(this IServiceCollection services)
    {
        services.AddSingleton(serviceProvider =>
        {
            // Fetch configuration provider
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            // Retrieve configuration values
            var account = configuration["CosmosDb:Account"];
            var key = configuration["CosmosDb:Key"];
            var databaseName = configuration["CosmosDb:DatabaseName"];
            var containerName = configuration["CosmosDb:ContainerName"];

            // Fail fast with clear error messages if configuration is missing
            ArgumentException.ThrowIfNullOrEmpty(account, "CosmosDb:Account configuration is missing.");
            ArgumentException.ThrowIfNullOrEmpty(key, "CosmosDb:Key configuration is missing.");
            ArgumentException.ThrowIfNullOrEmpty(databaseName, "CosmosDb:DatabaseName configuration is missing.");
            ArgumentException.ThrowIfNullOrEmpty(containerName, "CosmosDb:ContainerName configuration is missing.");

            // Initialize dependency graph
            var cosmosClient = new CosmosClient(account, key);
            var logger = serviceProvider.GetRequiredService<ILogger<CatalogService>>();

            return new CatalogService(
                cosmosClient,
                databaseName,
                containerName,
                logger);
        });

        return services;
    }
}
