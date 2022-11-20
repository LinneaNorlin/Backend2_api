using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class CategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }

    }
}
