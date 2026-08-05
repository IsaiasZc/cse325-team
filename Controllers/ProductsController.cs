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

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
    {
        try
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Entry(product).State = EntityState.Modified;
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.ImageUrl = updatedProduct.ImageUrl;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        catch (DbUpdateException ex)
        {
            return StatusCode(500, $"Database error: {ex.Message}");
        }

        catch (Exception ex)
        {
            return StatusCode(500, $"Unexpected error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        catch (DbUpdateException ex)
        {
            return StatusCode(500, $"Database error: {ex.Message}");
        }

        catch (Exception ex)
        {
            return StatusCode(500, $"Unexpected error: {ex.Message}");
        }
    }
}