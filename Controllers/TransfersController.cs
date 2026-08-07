using Microsoft.AspNetCore.Mvc;
using MarketInventoryApplication;
using MarketInventoryApplication.Services;
using Microsoft.AspNetCore.Authorization;

namespace MarketInventoryApplication.Controllers;

[Route("api/transfers")]
[ApiController]
[Authorize]
public class TransfersController : ControllerBase
{
    private readonly ITransferService _transferService;

    public TransfersController(ITransferService transferService)
    {
        _transferService = transferService;
    }


    [HttpGet]
    public async Task<ActionResult<List<TransferList>>> GetTransfers()
    {
        return await _transferService.GetTransfersAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<TransferList>> GetTransfer(int id)
    {
        var transfer = await _transferService.GetTransferAsync(id);

        if (transfer == null)
        {
            return NotFound();
        }

        return transfer;
    }


    [HttpPost]
    public async Task<ActionResult<TransferList>> CreateTransfer(
        TransferList transfer)
    {
        Console.WriteLine($"Authenticated: {User.Identity?.IsAuthenticated}");
        Console.WriteLine($"User: {User.Identity?.Name}");

        Console.WriteLine($"ProductId: {transfer.ProductId}");
        Console.WriteLine($"LocationId: {transfer.LocationId}");
        Console.WriteLine($"Quantity: {transfer.Quantity}");

        await _transferService.CreateTransferAsync(transfer);

        return Ok(transfer);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransfer(
        int id,
        TransferList transfer)
    {
        if (id != transfer.Id)
        {
            return BadRequest();
        }

        await _transferService.UpdateTransferAsync(transfer);

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransfer(int id)
    {
        await _transferService.DeleteTransferAsync(id);

        return NoContent();
    }
}