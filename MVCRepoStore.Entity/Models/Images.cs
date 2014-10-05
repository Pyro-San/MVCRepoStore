using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        public string ThumbUrl { get; set; }
        public string FullImageUrl { get; set; }
    }
}
