using System;

namespace MVCRepoStore.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SummaryDiscription { get; set; }
        public string Description { get; set; }
        public string ThumbnailFileName { get; set; }
        public string LargePhotoFileName { get; set; }
        public decimal ListPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public int CategoryId { get; set; }

        public Product()
        {
        }

        public Product(string name, string description, int categoryId, decimal listPrice, decimal discountPercent)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            ListPrice = listPrice;
            DiscountPercent = discountPercent;
        }

        public decimal DiscountAmount
        {
            get
            {
                decimal result;
                if (ListPrice > 0 && DiscountPercent > 0)
                    result = ListPrice * (DiscountPercent/100);
                else
                    result = 0;
                return result;
            }
        }

        public decimal DiscountPrice
        {
            get
            {
                decimal result = ListPrice - DiscountAmount;
                if (result < 0) result = 0;
                return result;
            }
        }
    }
}
