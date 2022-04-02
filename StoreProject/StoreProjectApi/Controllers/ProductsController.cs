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

    //[HttpGet("{artnr:length(3)}")]
    //public async Task<ActionResult<Product>> GetAsync(string artnr)
    //{
    //    var product = await _productsService.GetAsync(artnr);

    //    if (product is null)
    //    {
    //        return NotFound();
    //    }

    //    return product;
    //}

    //[HttpGet("article-number/{articleNumber}")]
    //public async Task<ActionResult<Product>> GetByArticleNumberAsync(string articleNumber)
    //{
    //    var product = await _productsService.GetByArticleNumberAsync(articleNumber);

    //    if (product is null)
    //    {
    //        return NotFound();
    //    }

    //    return product;
    //}
}
