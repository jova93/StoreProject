using System.Net;
using Newtonsoft.Json;

using StoreProjectApp.Models;

namespace StoreProjectApp.Services;

public class ProductsService
{
    private readonly HttpClient _httpClient;

    public ProductsService()
    {
        _httpClient = new HttpClient();

        //_httpClient = httpClient;
    }

    public async Task<List<Product>?> GetAsync()
    {
        string responseBody = await _httpClient.GetStringAsync("https://localhost:7213/api/products");
        
        var products = JsonConvert.DeserializeObject<List<Product>>(responseBody);

        return products;
    }

    public async Task<Product?> GetAsync(string id)
    {
        var uri = $"https://localhost:7213/api/products/{id}";
        var responseBody = await _httpClient.GetStringAsync(uri);
        var product = JsonConvert.DeserializeObject<Product>(responseBody);

        return product;
    }
}
