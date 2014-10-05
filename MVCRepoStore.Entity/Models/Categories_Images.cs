using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class Categories_Images
    {
        [Key]
        public int Id { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Images Image { get; set; }
    }
}
