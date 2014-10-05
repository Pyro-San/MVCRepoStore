using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class Categories_Products
    {
        [Key]
        public int Id { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Products Product { get; set; }
    }
}
