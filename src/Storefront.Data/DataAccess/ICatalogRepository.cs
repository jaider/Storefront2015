using System;
//using System.Linq;

namespace Storefront.Data.DataAccess
{
    public interface ICatalogRepository
    {
        System.Linq.IQueryable<Category> GetCategories();
    }
}