using MarketInventoryApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketInventoryApplication.Tests;

public class SeedDataTests
{
    [Fact]
    public void Initialize_CreatesTheExpectedProducts()
    {
        using var database = new TestDatabase();

        SeedData.Initialize(database.Context);

        var products = database.Context.Products
            .AsNoTracking()
            .OrderBy(product => product.Id)
            .ToList();

        Assert.Equal(6, products.Count);
        Assert.Equal(
            new[] { "Bacon", "Chicken", "Box", "Butter", "Mushroom", "Cheese" },
            products.Select(product => product.Name).ToArray());
        Assert.Equal(8.8, products[0].Price);
    }

    [Fact]
    public void Initialize_CreatesAdminAndStandardUsers()
    {
        using var database = new TestDatabase();

        SeedData.Initialize(database.Context);

        var users = database.Context.Users.AsNoTracking().ToList();

        Assert.Equal(2, users.Count);

        var admin = Assert.Single(users, user => user.Name == "Admin");
        Assert.Equal("adminpassword", admin.Password);
        Assert.Equal(2, admin.Level);

        var standardUser = Assert.Single(users, user => user.Name == "User");
        Assert.Equal("userpassword", standardUser.Password);
        Assert.Equal(1, standardUser.Level);
    }

    [Fact]
    public void Initialize_DoesNotDuplicateRecordsWhenCalledTwice()
    {
        using var database = new TestDatabase();

        SeedData.Initialize(database.Context);
        SeedData.Initialize(database.Context);

        Assert.Equal(6, database.Context.Products.Count());
        Assert.Equal(2, database.Context.Users.Count());
    }
}
