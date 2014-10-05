using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class Products_Images
    {
        [Key]
        public int Id { get; set; }
        public virtual Products Product { get; set; }
        public virtual Images Image { get; set; }
    }
}
