using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal BaseUnitPrice { get; set; }
        public decimal DiscountPercent { get; set; }

        //public virtual List<ProductReviews> Reviews { get; set; }
        //public virtual List<ProductDescriptions> Descriptions { get; set; }
    }
}
