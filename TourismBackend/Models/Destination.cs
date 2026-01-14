using System.ComponentModel.DataAnnotations;

namespace TourismBackend.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Slug { get; set; } 
        public string Title { get; set; }
        public string BannerImg { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 

        public string? HotelUrl { get; set; }
        
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<DestinationImage> Gallery { get; set; } = new List<DestinationImage>();
    }
}