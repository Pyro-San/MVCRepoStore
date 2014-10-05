using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class ProductCultureDetail
    {
        [Key]
        public int ProductCultureDetailId { get; set; }
        public string Desctiption { get; set; }
        public string ShortDescription { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Products Product { get; set; }
        public virtual Cultures Culture { get; set; }
    }
}
