using MarketInventoryApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketInventoryApplication.Tests;

public class ProductsControllerTests
{
    [Fact]
    public async Task GetProducts_WhenDatabaseIsEmpty_ReturnsAnEmptyList()
    {
        using var database = new TestDatabase();
        var controller = new ProductsController(database.Context);

        var response = await controller.GetProducts();

        var products = Assert.IsType<List<Product>>(response.Value);
        Assert.Empty(products);
    }

    [Fact]
    public async Task GetProducts_ReturnsProductsOrderedByIdDescending()
    {
        using var database = new TestDatabase();
        database.Context.Products.AddRange(
            new Product { Name = "First product", Description = "First", Price = 1, ImageUrl = "first" },
            new Product { Name = "Second product", Description = "Second", Price = 2, ImageUrl = "second" });
        await database.Context.SaveChangesAsync();

        var controller = new ProductsController(database.Context);

        var response = await controller.GetProducts();

        var products = Assert.IsType<List<Product>>(response.Value);
        Assert.Equal(new[] { "Second product", "First product" }, products.Select(product => product.Name));
    }

    [Fact]
    public async Task CreateProduct_SavesTheProductAndReturnsIt()
    {
        using var database = new TestDatabase();
        var controller = new ProductsController(database.Context);
        var product = new Product
        {
            Name = "Rice",
            Description = "A bag of rice",
            Price = 10.5,
            ImageUrl = "rice-image"
        };

        var response = await controller.CreateProduct(product);

        var result = Assert.IsType<OkObjectResult>(response.Result);
        var returnedProduct = Assert.IsType<Product>(result.Value);
        Assert.True(returnedProduct.Id > 0);

        database.Context.ChangeTracker.Clear();
        var savedProduct = await database.Context.Products.FindAsync(returnedProduct.Id);

        Assert.NotNull(savedProduct);
        Assert.Equal("Rice", savedProduct!.Name);
        Assert.Equal(10.5, savedProduct.Price);
    }

    [Fact]
    public async Task UpdateProduct_WhenProductExists_UpdatesItsFields()
    {
        using var database = new TestDatabase();
        var product = new Product
        {
            Name = "Old name",
            Description = "Old description",
            Price = 1,
            ImageUrl = "old-image"
        };
        database.Context.Products.Add(product);
        await database.Context.SaveChangesAsync();

        var updatedProduct = new Product
        {
            Name = "New name",
            Description = "New description",
            Price = 9.75,
            ImageUrl = "new-image"
        };
        var controller = new ProductsController(database.Context);

        var response = await controller.UpdateProduct(product.Id, updatedProduct);

        Assert.IsType<NoContentResult>(response);

        database.Context.ChangeTracker.Clear();
        var savedProduct = await database.Context.Products.FindAsync(product.Id);

        Assert.NotNull(savedProduct);
        Assert.Equal("New name", savedProduct!.Name);
        Assert.Equal("New description", savedProduct.Description);
        Assert.Equal(9.75, savedProduct.Price);
        Assert.Equal("new-image", savedProduct.ImageUrl);
    }

    [Fact]
    public async Task UpdateProduct_WhenProductDoesNotExist_ReturnsNotFound()
    {
        using var database = new TestDatabase();
        var controller = new ProductsController(database.Context);

        var response = await controller.UpdateProduct(99, new Product { Name = "Missing" });

        Assert.IsType<NotFoundResult>(response);
    }

    [Fact]
    public async Task DeleteProduct_WhenProductExists_RemovesTheProduct()
    {
        using var database = new TestDatabase();
        var product = new Product
        {
            Name = "To delete",
            Description = "Product to remove",
            Price = 3.5,
            ImageUrl = "delete-image"
        };
        database.Context.Products.Add(product);
        await database.Context.SaveChangesAsync();
        var controller = new ProductsController(database.Context);

        var response = await controller.DeleteProduct(product.Id);

        Assert.IsType<NoContentResult>(response);

        database.Context.ChangeTracker.Clear();
        Assert.Null(await database.Context.Products.FindAsync(product.Id));
    }

    [Fact]
    public async Task DeleteProduct_WhenProductDoesNotExist_ReturnsNotFound()
    {
        using var database = new TestDatabase();
        var controller = new ProductsController(database.Context);

        var response = await controller.DeleteProduct(99);

        Assert.IsType<NotFoundResult>(response);
    }
}
