using Catalog.API.Models;
using Microsoft.Azure.Cosmos;
namespace Catalog.API.Services;

public class CatalogService
{
    private readonly Container _container;
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(CosmosClient cosmosClient, string databaseName, string containerName, ILogger<CatalogService> logger)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
        _logger = logger;
    }

    public async Task AddProductPage(ProductPage productPage)
    {
        try
        {
            var partitionKey = new PartitionKey(productPage.Id);

            await _container.UpsertItemAsync(productPage, partitionKey);
        }
        catch (CosmosException ex)
        {
            _logger.LogError($"CosmosDB Error: {ex.StatusCode} - {ex.Message}");
            _logger.LogError($"ActivityId: {ex.ActivityId}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected Error: {ex.Message}");
        }
    }

    public async Task<ProductPage?> GetProductPage(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<ProductPage>(id, new PartitionKey(id));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }
}