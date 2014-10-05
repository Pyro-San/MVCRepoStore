using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class ProductDescriptions
    {
        [Key]
        public int ProductDescriptionId { get; set; }
        public int CultureId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
    }
}
