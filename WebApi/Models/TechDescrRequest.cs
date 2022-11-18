using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class TechDescrRequest
    {
        public string ArtNumber { get; set; } = null!;

        public string TechDescrDetails { get; set; } = null!;

    }
}
