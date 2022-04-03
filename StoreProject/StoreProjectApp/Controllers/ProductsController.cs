using Microsoft.AspNetCore.Mvc;
using StoreProjectApp.Services;
using StoreProjectApp.ViewModels;
using StoreProjectApp.Models;

namespace StoreProjectApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductsService _productsService;

    // GET: Products
    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }
    public async Task<IActionResult> Index()
    {
        var products = await _productsService.GetAsync();

        return View(products);
    }

    // GET: Products/Details/Id
    public async Task<IActionResult> Details(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _productsService.GetAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: Products/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Products/Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateProduct newProduct)
    {
        if (ModelState.IsValid)
        {
            var result = await _productsService.PostAsync(newProduct);

            return RedirectToAction(nameof(Index));
        }
        
        return View(newProduct);
    }

    // GET: Products/Delete/Id
    public async Task<IActionResult> Delete(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _productsService.GetAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Products/Delete/Id
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var result = await _productsService.RemoveAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
