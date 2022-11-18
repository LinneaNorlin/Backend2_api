namespace WebApi.Models
{
    public class ProductResponse
    {
        public Guid Id { get; set; } 

        public string ArticleNumber { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;
    }
}
