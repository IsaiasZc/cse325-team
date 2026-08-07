using MarketInventoryApplication;

namespace MarketInventoryApplication.Services;

public interface ITransferService
{
    Task<List<TransferList>> GetTransfersAsync();

    Task<TransferList?> GetTransferAsync(int id);

    Task CreateTransferAsync(TransferList transfer);

    Task UpdateTransferAsync(TransferList transfer);

    Task DeleteTransferAsync(int id);
}