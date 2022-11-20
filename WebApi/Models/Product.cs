using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ArticleNumber { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = "No description for this product";


        public TechDescrRequest TechDescription { get; set; }

        public CategoryRequest Category { get; set; }
    }
}
