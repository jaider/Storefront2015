using Microsoft.Data.Entity;
using Storefront.Sql.Entities;

namespace Storefront.Sql
{
    public class DB : DbContext
    {
        internal DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptions options)
        {
            var connectionString = @"Server=localhost;Database=StorefrontDB;Trusted_Connection=True;";
            options.UseSqlServer(connectionString);
        }
    }
}