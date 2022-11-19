namespace WebApi.Models
{
    public class CategoryResponse
    {
        public CategoryRequest Category { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public string ArticleNumber { get; set; } = null!;

    }
}
