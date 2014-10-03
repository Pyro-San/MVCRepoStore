using System.Collections.Generic;

namespace MVCRepoStore.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
