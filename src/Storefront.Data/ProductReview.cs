using System;

namespace Storefront.Data
{
    public class ProductReview
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewBody { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
    }
}