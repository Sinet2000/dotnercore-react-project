using System;

namespace Website.ViewModels.ProductVM
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SKU { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }

        public DateTime CreateDate { get; set; }

        public string ImageLink { get; set; }
    }
}
