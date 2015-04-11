using Storefront.Data.DataAccess;
using System;
using Xunit;
using System.Linq;

namespace Storefront.IntegrationTests
{
    public class CatalogIntegrationTest
    {
        [Fact]
        public void SqlCatalogRepository_ShouldReturn_Categories_AsQueryable()
        {
            var rep = new SqlCatalogRepository();

            var qry = rep.GetCategories();
            Assert.NotNull(qry);

            var catList = (from c in qry
                           where c.ID == 1
                           select c).ToList();

            Assert.Single(catList);

            Assert.Equal(catList[0].Name, "category1");
        }
    }
}
