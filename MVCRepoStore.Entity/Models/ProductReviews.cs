using System;
using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class ProductReviews
    {
        [Key]
        public int ProductReviewId { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Email { get; set; }

        public virtual Products Product { get; set; }
    }
}
