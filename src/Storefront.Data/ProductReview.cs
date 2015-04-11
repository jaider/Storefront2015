using System;

namespace Storefront.Data
{
    public class ProductReview
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
    }
}