// gestionează interacțiunea cu fronted ul, permițând afișarea detaliilor și a recenziilor pe baza numelui 
//destinației. Pentru salvarea rezervărilor trece sarcina la BookingManager
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourismBackend.Data;
using TourismBackend.Models;
using TourismBackend.Services;

namespace TourismBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly TourismContext _context;

        public DestinationsController(TourismContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestinations()
        {
            return await _context.Destinations
                                 .Include(d => d.Gallery)
                                 .Include(d => d.Reviews)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<Destination>> GetDestination([FromRoute] string slug)
        {
            var destination = await _context.Destinations
                                            .Include(d => d.Gallery)
                                            .Include(d => d.Reviews)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(d => d.Slug == slug);

            if (destination == null)
            {
                return NotFound(new { message = "Destinația nu a fost găsită." });
            }

            return Ok(destination);
        }

        [HttpPost("{slug}/booking")]
        public async Task<IActionResult> PostBooking([FromRoute] string slug, [FromBody] Booking booking)
        {
            var dest = await _context.Destinations.FirstOrDefaultAsync(d => d.Slug == slug);
            
            if (dest == null) 
            {
                return NotFound(new { message = "Destinația nu există." });
            }

            booking.Id = 0; 
            booking.DestinationId = dest.Id;
            booking.CreatedAt = DateTime.Now;

            try 
            {
                BookingManager.Instance.AddBooking(booking, _context);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Eroare la salvarea rezervării.", error = ex.Message });
            }

            return Ok(new { message = "Rezervare salvată cu succes!" });
        }

        [HttpPost("{slug}/reviews")]
        public async Task<IActionResult> PostReview([FromRoute] string slug, [FromBody] Review review)
        {
            var dest = await _context.Destinations.FirstOrDefaultAsync(d => d.Slug == slug);

            if (dest == null)
            {
                return NotFound(new { message = "Destinația nu există." });
            }

            review.Id = 0;
            review.DestinationId = dest.Id; 

            try
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Eroare la salvarea recenziei.", error = ex.Message });
            }

            return Ok(new { message = "Review salvat cu succes!" });
        }
    }
}