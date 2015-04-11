using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using Storefront.Sql;
using System;

namespace Storefront.Data.Migrations
{
    [ContextType(typeof(Storefront.Sql.DB))]
    public class DBModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("Storefront.Sql.Entities.Category", b =>
                    {
                        b.Property<int>("CategoryID")
                            .GenerateValueOnAdd();
                        b.Property<string>("CategoryName");
                        b.Property<int?>("ParentID");
                        b.Key("CategoryID");
                    });
                
                return builder.Model;
            }
        }
    }
}