using Storefront.Data;
using Storefront.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Storefront.Services
{
    public class CatalogService
    {
        ICatalogRepository _repository = null;

        /// <summary>
        /// Create a Catalog Service based on the passed-in repository
        /// </summary>
        /// <param name="repository">An ICatalogRepository</param>
        public CatalogService(ICatalogRepository repository)
        {
            _repository = repository;
            if (_repository == null) {
                throw new InvalidOperationException("Catalog Repository cannot be null");
            }
        }

        /// <summary>
        /// Get the categories and subcategories from the DB
        /// </summary>
        /// <returns>Category Collection</returns>
        public IList<Category> GetCategories() {
            var rawCategories = _repository.GetCategories().ToList();

            var parents = (from c in rawCategories
                          where c.ParentID == 0
                          select c).ToList();

            parents.ForEach(p =>
            {
                p.SubCategories = (from c in rawCategories
                                   where c.ParentID == p.ID
                                   select c).ToList();
            });

            return parents;
        }
    }
}