using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercent { get; set; }

        public virtual List<ProductReviews> Reviews { get; set; }
        public virtual List<ProductDescriptions> Descriptions { get; set; }
    }
}
