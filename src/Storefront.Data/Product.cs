using System;

namespace Storefront.Data
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SummaryDescription { get; set; }
        public string Description { get; set; }
        public string ThumbnailFileName { get; set; }
        public string LargePhotoFileName { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public int CategoryID { get; set; }

        public Product() { }

        public Product(string name, string description, int categoryID, decimal price, decimal discountPercent)
        {
            this.Name = name;
            this.Description = description;
            this.CategoryID = categoryID;
            this.Price = price;
            this.DiscountPercent = discountPercent;
        }
    }
}