namespace MarketInventoryApplication;

public static class ProductSearch
{
    public static IEnumerable<Product> Filter(IEnumerable<Product> products, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return products;
        }

        var normalizedTerm = searchTerm.Trim();

        return products.Where(product =>
            !string.IsNullOrWhiteSpace(product.Name) &&
            product.Name.Contains(normalizedTerm, StringComparison.OrdinalIgnoreCase));
    }
}
