using System.Globalization;

namespace MarketInventoryApplication.Tests;

public class ProductTests
{
    [Theory]
    [InlineData(8.8, "8.80")]
    [InlineData(12, "12.00")]
    public void GetFormattedPrice_UsesTwoDecimalPlaces(double price, string expected)
    {
        var previousCulture = CultureInfo.CurrentCulture;

        try
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var product = new Product
            {
                Price = price
            };

            Assert.Equal(expected, product.GetFormattedPrice());
        }
        finally
        {
            CultureInfo.CurrentCulture = previousCulture;
        }
    }
}
