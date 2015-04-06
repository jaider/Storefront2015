using System.Linq;

namespace Storefront.Data.Filters
{
    public static class ProductFilters
    {
        /// <summary>
        /// Filter The query by CategoryID
        /// </summary>
        /// <param name="categoryID">The category ID to filter by</param>
        /// <returns>IQueryable of Products</returns>
        public static IQueryable<Product> WithCategory(this IQueryable<Product> qry, int categoryID)
        {
            return from p in qry
                   where p.CategoryID == categoryID
                   select p;
        }

        /// <summary>
        /// Filter the query by ProductID
        /// </summary>
        /// <param name="productID">The product ID to filter by</param>
        /// <returns>IQueryable of Products</returns>
        public static IQueryable<Product> WithID(this IQueryable<Product> qry, int productID)
        {
            return from p in qry
                   where p.ID == productID
                   select p;
        }

    }
}