using Storefront.Data;
using Xunit;

namespace Storefront.Tests
{
    public class CatalogTests
    {
        [Fact]
        public void Product_Discount_Ammount_Is_Valid() {
            var p = new Product();
            p.ListPrice = 100;
            p.DiscountPercent = 40;

            Assert.Equal(p.DiscountAmount, 40);
        }

        [Fact]
        public void Product_Discount_Price_Is_Valid() {
            var p = new Product();
            p.ListPrice = 100;
            p.DiscountPercent = 40;

            Assert.Equal(p.DiscountPrice, 60);
        }
    }
}