using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class ProductDescriptions
    {
        [Key]
        public int ProductDescriptionId { get; set; }
        public string Description { get; set; }

        public virtual Cultures Culture { get; set; }
        public virtual Products Product { get; set; }
    }
}
