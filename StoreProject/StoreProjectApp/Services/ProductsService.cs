using System.Net;
using Newtonsoft.Json;
using StoreProjectApp.Models;
using StoreProjectApp.ViewModels;

namespace StoreProjectApp.Services;

public class ProductsService
{
    private readonly HttpClient _httpClient;

    public ProductsService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Product>?> GetAsync()
    {
        var uri = $"https://localhost:7213/api/products";
        var responseBody = await _httpClient.GetStringAsync(uri);
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

    public async Task<bool> PostAsync(CreateProduct newProduct)
    {
        var uri = $"https://localhost:7213/api/products";
        var responseBody = await _httpClient.PostAsJsonAsync(uri, newProduct);

        return responseBody.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(string id, EditProduct updatedProduct)
    {
        var uri = $"https://localhost:7213/api/products/{id}";
        var responseBody = await _httpClient.PutAsJsonAsync(uri, updatedProduct);

        return responseBody.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        var uri = $"https://localhost:7213/api/products/{id}";
        var responseBody = await _httpClient.DeleteAsync(uri);

        return responseBody.IsSuccessStatusCode;
    }
}
