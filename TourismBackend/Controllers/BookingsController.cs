// A permite vizualizarea listei complete a tuturor rezervărilor din sistem, pentru partea de admin
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using TourismBackend.Data;
using TourismBackend.Models;
using TourismBackend.Services;

namespace TourismBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly TourismContext _context;

        public BookingsController(TourismContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings
                                 .Include(b => b.Destination)
                                 .OrderByDescending(b => b.CreatedAt)
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            var dest = await _context.Destinations.FindAsync(booking.DestinationId);
            if (dest == null)
            {
                return BadRequest("Destinația selectată nu există.");
            }

            BookingManager.Instance.AddBooking(booking, _context);
            
            return CreatedAtAction("GetBookings", new { id = booking.Id }, booking);
        }
    }
}