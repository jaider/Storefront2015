using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using Storefront.Sql;
using System;

namespace Storefront.Data.Migrations
{
    [ContextType(typeof(Storefront.Sql.DB))]
    public partial class InitialSchema : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201504110424090_InitialSchema";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta3-12166";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
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