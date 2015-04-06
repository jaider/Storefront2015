using Storefront.Data.DataAccess;
using System;
using Storefront.Data;
using System.Linq;
using System.Collections.Generic;

namespace Storefront.Tests
{
    public class TestCatalogRepository : ICatalogRepository
    {
        public IQueryable<Category> GetCategories()
        {
            IList<Category> result = new List<Category>();

            for (int i = 1; i <= 2; i++)
            {
                var category = new Category();
                category.ID = i;
                category.Name = "Parent" + i.ToString();
                category.ParentID = 0;

                int subCategoryID = 10 * i;
                for (int x = 10; x < 15; x++)
                {
                    var sub = new Category();
                    sub.ID = subCategoryID;
                    sub.Name = "Sub" + subCategoryID.ToString();
                    sub.ParentID = i;
                    result.Add(sub);

                    subCategoryID++;
                }

                result.Add(category);
            }

            return result.AsQueryable();
        }

        public IQueryable<Product> GetProducts()
        {
            var result = new List<Product>();
            int uniqueProductID = 1;

            var categories = GetCategories().Where(c => c.ParentID > 0);

            foreach (var c in categories)
            {
                for (int y = 1; y <= 5; y++)
                {
                    var p = new Product();
                    p.Name = "Product" + uniqueProductID.ToString();
                    p.ID = uniqueProductID;
                    p.Price = y * 5.68m;
                    p.Description = "Test Description";

                    p.CategoryID = c.ID;
                    uniqueProductID++;
                    result.Add(p);
                }
            }

            return result.AsQueryable();
        }
    }
}