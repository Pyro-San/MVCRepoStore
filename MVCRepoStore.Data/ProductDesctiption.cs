namespace MVCRepoStore.Data
{
  public  class ProductDesctiption
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Locale { get; set; }
        public int ProductId { get; set; }

        public ProductDesctiption()
        {
        }

        public ProductDesctiption(string body, string locale, int productId)
        {
            Body = body;
            Locale = locale;
            ProductId = productId;
        }
    }
}
