using System;
using System.Linq;

namespace Storefront.Data.DataAccess
{
    public interface ICatalogRepository
    {
        IQueryable<Category> GetCategories();

        IQueryable<Product> GetProducts();
    }
}