using Microsoft.EntityFrameworkCore;

namespace MarketInventoryApplication.Data;

public class MarketInventoryContext : DbContext
{
    public MarketInventoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<TransferList> TransferList { get; set; }
    public DbSet<User> Users { get; set; }
}