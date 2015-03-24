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
        public decimal ListPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public int CategoryID { get; set; }

        public decimal DiscountAmount
        {
            get
            {
                decimal result = 0;
                if (this.ListPrice > 0 && this.DiscountPercent > 0) {
                    decimal discountRate = this.DiscountPercent * .01m;
                    result = this.ListPrice * discountRate;
                }

                return result;
            }
        }

        public decimal DiscountPrice
        {
            get
            {
                return ListPrice - DiscountAmount;
            }
        }
    }
}