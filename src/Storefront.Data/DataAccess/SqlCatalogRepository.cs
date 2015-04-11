using Storefront.Sql;
using System;
using System.Linq;

namespace Storefront.Data.DataAccess
{
    public class SqlCatalogRepository : ICatalogRepository
    {
        public IQueryable<Category> GetCategories()
        {
            var ctx = new DB();
            return from c in ctx.Categories
                    select new Category
                    {
                        ID = c.CategoryID,
                        Name = c.CategoryName,
                        ParentID = c.ParentID ?? 0
                    };
        }

        public IQueryable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}