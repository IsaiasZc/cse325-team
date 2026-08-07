using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MarketInventoryApplication.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MarketInventoryContext>
{
    public MarketInventoryContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MarketInventoryContext>();
        optionsBuilder.UseSqlite("Data Source=market.db");
        return new MarketInventoryContext(optionsBuilder.Options);
    }
}
