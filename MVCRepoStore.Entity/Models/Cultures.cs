using System.ComponentModel.DataAnnotations;

namespace MVCRepoStore.Entity.Models
{
    public class Cultures
    {
        [Key]
        public int CultureId { get; set; }
        public string LanguageCode { get; set; }
        public string Locale { get; set; }
        public string DefaultCurrencyCode { get; set; }
    }
}
