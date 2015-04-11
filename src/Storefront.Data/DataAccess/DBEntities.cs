namespace Storefront.Sql.Entities
{
    internal class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int? ParentID { get; set; }
    }
}