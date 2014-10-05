using System;

namespace MVCRepoStore.Data
{
    public class ProductReview
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Email { get; set; }
        public string ProductId { get; set; }

        public ProductReview()
        {
        }

        public ProductReview(string author, string body, DateTime createdOn, string email, string productId)
        {
            Author = author;
            Body = body;
            CreatedOn = createdOn;
            Email = email;
            ProductId = productId;
        }
    }
}
