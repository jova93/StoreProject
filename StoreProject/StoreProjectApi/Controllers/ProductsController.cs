using StoreProjectApi.Models;
using StoreProjectApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace StoreProjectApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService) =>
        _productsService = productsService;

    [HttpGet]
    public async Task<List<Product>> GetAsync() =>
        await _productsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Product>> GetAsync(string id)
    {
        var product = await _productsService.GetAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Product newProduct)
    {
        await _productsService.CreateAsync(newProduct);

        return CreatedAtAction(nameof(GetAsync), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Product updatedProduct)
    {
        var product = await _productsService.GetAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        updatedProduct.Id = product.Id;

        await _productsService.UpdateAsync(id, updatedProduct);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var product = await _productsService.GetAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        await _productsService.RemoveAsync(id);

        return NoContent();
    }
}
