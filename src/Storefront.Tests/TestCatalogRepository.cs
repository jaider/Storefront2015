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

                for (int x = 10; x < 15; x++)
                {
                    var sub = new Category();
                    sub.ID = x;
                    sub.Name = "Sub" + x.ToString();
                    sub.ParentID = i;
                    result.Add(sub);
                }

                result.Add(category);
            }

            return result.AsQueryable<Category>();
        }
    }
}