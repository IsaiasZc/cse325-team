using MarketInventoryApplication.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MarketInventoryApplication.Tests;

public sealed class TestDatabase : IDisposable
{
    private readonly SqliteConnection connection;

    public MarketInventoryContext Context { get; }

    public TestDatabase()
    {
        connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<MarketInventoryContext>()
            .UseSqlite(connection)
            .Options;

        Context = new MarketInventoryContext(options);
        Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        Context.Dispose();
        connection.Dispose();
    }
}
