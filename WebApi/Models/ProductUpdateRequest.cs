namespace WebApi.Models
{
    public class ProductUpdateRequest
    {
        public string ArticleNumber { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;
    }
}
