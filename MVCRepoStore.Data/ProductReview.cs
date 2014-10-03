using System;

namespace MVCRepoStore.Data
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewBody { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
    }
}
