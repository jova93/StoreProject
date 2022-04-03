using StoreProjectApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace StoreProjectApi.Services;

public class ProductsService
{
    private readonly IMongoCollection<Product> _productsCollection;

    public ProductsService(
        IOptions<StoreProjectDatabaseSettings> storeProjectDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            storeProjectDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            storeProjectDatabaseSettings.Value.DatabaseName);

        _productsCollection = mongoDatabase.GetCollection<Product>(
            storeProjectDatabaseSettings.Value.ProductsCollectionName);
    }

    public async Task<List<Product>> GetAsync() =>
        await _productsCollection.Find(_ => true).ToListAsync();

    public async Task<Product?> GetAsync(string id) =>
        await _productsCollection.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Product newProduct) =>
        await _productsCollection.InsertOneAsync(newProduct);

    public async Task RemoveAsync(string id) =>
        await _productsCollection.DeleteOneAsync(p => p.Id == id);
}
