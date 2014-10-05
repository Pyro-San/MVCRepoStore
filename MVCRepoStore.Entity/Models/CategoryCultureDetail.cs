using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class CategoryCultureDetail
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual Cultures Culture { get; set; }
    }
}
