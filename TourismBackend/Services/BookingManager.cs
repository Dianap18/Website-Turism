// implementarea Design Pattern-ului Singleton, care centralizează toată logica de procesare a rezervărilor
//Rolul său este să asigure consistența datelor, salvându-le în RAM și în baza de date SQL
using TourismBackend.Data;
using TourismBackend.Models;

namespace TourismBackend.Services
{
    public class BookingManager
    {
        private static BookingManager _instance;
        private static readonly object _lock = new object();
        
        private List<Booking> _bookings;

        private BookingManager()
        {
            _bookings = new List<Booking>();
        }

        public static BookingManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new BookingManager();
                    }
                    return _instance;
                }
            }
        }

        public void AddBooking(Booking booking, TourismContext context)
        {
            lock (_lock)
            {
                _bookings.Add(booking);
            }

            context.Bookings.Add(booking);
            context.SaveChanges(); 
        }

        public List<Booking> GetAllBookings()
        {
            return _bookings;
        }
        
        public void LoadFromDatabase(TourismContext context)
        {
            if (_bookings.Count == 0)
            {
                _bookings = context.Bookings.ToList();
            }
        }
    }
}