using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketInventoryApplication.Data;

namespace MarketInventoryApplication.Controllers;

[Route("products")]
[ApiController]
public class ProductsController : Controller
{
    private readonly MarketInventoryContext _db;

    public ProductsController(MarketInventoryContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return (await _db.Products.ToListAsync()).OrderByDescending(s => s.Id).ToList();
    }
}