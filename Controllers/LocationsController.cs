using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketInventoryApplication.Data;

namespace MarketInventoryApplication.Controllers;

[Route("api/locations")]
[ApiController]
public class LocationsController : Controller
{
    private readonly MarketInventoryContext _db;

    public LocationsController(MarketInventoryContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Location>>> GetLocations()
    {
        return await _db.Locations
            .OrderBy(l => l.Name)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Location>> CreateLocation(Location location)
    {
        location.Id = 0;

        _db.Locations.Add(location);

        await _db.SaveChangesAsync();

        return Ok(location);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        var location = await _db.Locations.FindAsync(id);

        if (location == null)
        {
            return NotFound();
        }

        _db.Locations.Remove(location);

        await _db.SaveChangesAsync();

        return NoContent();
    }
}