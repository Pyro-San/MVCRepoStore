using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
