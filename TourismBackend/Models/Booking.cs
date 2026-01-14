namespace TourismBackend.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Period { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public decimal TotalPrice { get; set; }
        
        public int DestinationId { get; set; } 
        public Destination? Destination { get; set; } 
    }
}