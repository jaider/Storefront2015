using Storefront.Data;
using Storefront.Services;
using Xunit;
using System.Linq;

namespace Storefront.Tests
{
    public class CatalogTests
    {
        CatalogService catalogService;

        public CatalogTests()
        {
            var rep = new TestCatalogRepository();
            catalogService = new CatalogService(rep);
        }

        #region Product Tests

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

        #endregion

        [Fact]
        public void CatalogRepository_Repository_IsNotNull()
        {
            var rep = new TestCatalogRepository();
            Assert.NotNull(rep.GetCategories());
        }

        [Fact]
        public void CatalogService_Can_Get_Categories_From_Service()
        {
            var categories = catalogService.GetCategories();
            Assert.NotEmpty(categories);
        }

        [Fact]
        public void CatalogService_Can_Group_ParentCategories()
        {
            var categories = catalogService.GetCategories();
            Assert.Equal(2, categories.Count);
        }

        [Fact]
        public void CatalogService_Can_Group_SubCategories()
        {
            var categories = catalogService.GetCategories();
            Assert.Equal(5, categories.First().SubCategories.Count);
        }
    }
}