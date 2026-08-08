namespace MarketInventoryApplication.Tests;

public class ProductSearchTests
{
    [Fact]
    public void Filter_ReturnsProductsWhoseNamesContainTheSearchTerm()
    {
        var products = new[]
        {
            new Product { Name = "Red apples" },
            new Product { Name = "Bananas" },
            new Product { Name = "Green apples" }
        };

        var result = ProductSearch.Filter(products, "APPLE").ToList();

        Assert.Equal(new[] { "Red apples", "Green apples" }, result.Select(product => product.Name));
    }

    [Fact]
    public void Filter_IgnoresProductsWithoutNames()
    {
        var products = new[]
        {
            new Product { Name = null! },
            new Product { Name = "Rice" }
        };

        var result = ProductSearch.Filter(products, "rice").ToList();

        var product = Assert.Single(result);
        Assert.Equal("Rice", product.Name);
    }
}
