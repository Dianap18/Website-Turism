using System.Text.Json.Serialization;

namespace TourismBackend.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Stars { get; set; }
        public string Comment { get; set; } = string.Empty;
        
        public int DestinationId { get; set; }

        [JsonIgnore]
        public Destination? Destination { get; set; }
    }
}