using Microsoft.EntityFrameworkCore;
using MarketInventoryApplication.Data;
using MarketInventoryApplication;
using System.Security.Claims;


namespace MarketInventoryApplication.Services;

public class TransferService : ITransferService
{
    private readonly MarketInventoryContext _db;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public TransferService(MarketInventoryContext db, IHttpContextAccessor httpContextAccessor)
    {
        _db = db;
        _httpContextAccessor = httpContextAccessor;
    }



    public async Task<List<TransferList>> GetTransfersAsync()
    {
        return await _db.TransferList
            .Include(t => t.Product)
            .Include(t => t.Location)
            .Include(t => t.ModifiedByUser)
            .ToListAsync();
    }



    public async Task<TransferList?> GetTransferAsync(int id)
    {
        return await _db.TransferList
            .Include(t => t.Product)
            .Include(t => t.Location)
            .Include(t => t.ModifiedByUser)
            .FirstOrDefaultAsync(t => t.Id == id);
    }



    public async Task CreateTransferAsync(TransferList transfer)
    {
        transfer.Id = 0;

        transfer.ModifiedByUserId = GetCurrentUserId();
        transfer.ModifiedDate = DateTime.UtcNow;

        _db.TransferList.Add(transfer);

        await _db.SaveChangesAsync();
    }



    public async Task UpdateTransferAsync(TransferList transfer)
    {
         var existing = await _db.TransferList
        .FindAsync(transfer.Id);


        if (existing == null)
        return;


        existing.ProductId = transfer.ProductId;
        existing.LocationId = transfer.LocationId;
        existing.Quantity = transfer.Quantity;


        existing.ModifiedByUserId = GetCurrentUserId();
        existing.ModifiedDate = DateTime.UtcNow;

       

        await _db.SaveChangesAsync();
    }



    public async Task DeleteTransferAsync(int id)
    {
        var transfer = await _db.TransferList.FindAsync(id);

        if (transfer != null)
        {
            _db.TransferList.Remove(transfer);

            await _db.SaveChangesAsync();
        }
    }
 private int GetCurrentUserId()
{
    var user = _httpContextAccessor.HttpContext?.User;

    if (user == null)
    {
        throw new Exception("No HttpContext");
    }


    var userId = user.FindFirst(
        ClaimTypes.NameIdentifier)?.Value;


    if (string.IsNullOrEmpty(userId))
    {
        throw new Exception("No user id claim found");
    }


    return int.Parse(userId);
}
}