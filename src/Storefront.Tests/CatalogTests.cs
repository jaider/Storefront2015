using Storefront.Data;
using Storefront.Data.Filters;
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

        #region Category Tests

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

        #endregion


        #region Product Tests

        [Fact]
        public void Product_ShouldHave_Name_Description_Category_Price_Discount_Fields()
        {
            var p = new Product("TestName", "TestDescription", 10, 100, 20);
            Assert.Equal(p.Name, "TestName");
            Assert.Equal(p.Description, "TestDescription");
            Assert.Equal(p.CategoryID, 10);
            Assert.Equal(p.Price, 100);
            Assert.Equal(p.DiscountPercent, 20);
        }

        [Fact]
        public void CatalogRepository_Contains_Products()
        {
            var rep = new TestCatalogRepository();
            Assert.NotNull(rep.GetProducts());
        }

        [Fact]
        public void CatalogRepository_Each_Category_Contains_5_Products()
        {
            var rep = new TestCatalogRepository();
            var categories = rep.GetCategories().Where(c => c.ParentID != 0).ToList();
            var products = rep.GetProducts().ToList();

            foreach (var c in categories)
            {
                Assert.Equal(products.Count(p => p.CategoryID == c.ID), 5);
            }
        }

        [Fact]
        public void CatalogRepository_Has_Category_Filter_For_Products()
        {
            var rep = new TestCatalogRepository();
            var products = rep.GetProducts().WithCategory(11).ToList();

            Assert.NotNull(products);
        }

        [Fact]
        public void CatalogRepository_ProductFiter_Returns_5_Products_With_Category_11()
        {
            var rep = new TestCatalogRepository();
            var products = rep.GetProducts().WithCategory(11).ToList();

            Assert.Equal(products.Count, 5);
        }

        [Fact]
        public void CatalogService_Returns_5_Products_With_Category_11()
        {
            var products = catalogService.GetProductsByCategory(11);
            Assert.Equal(products.Count, 5);
        }

        [Fact]
        public void CatalogRepository_Returns_Single_Product_When_Filtered_ByID_1()
        {
            var rep = new TestCatalogRepository();
            Assert.Single(rep.GetProducts().WithID(1));
        }

        [Fact]
        public void CatalogService_Returns_Single_Product_When_Filtered_ByID_1()
        {
            var product = catalogService.GetProductByID(1);
            Assert.NotNull(product);
        }

        #endregion
    }
}