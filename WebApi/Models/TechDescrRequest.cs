using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace WebApi.Models
{
    public class TechDescrRequest
    {
        public string ArtNumber { get; set; } = null!;

        public string TechDescrDetails { get; set; } = null!;

    }
}
