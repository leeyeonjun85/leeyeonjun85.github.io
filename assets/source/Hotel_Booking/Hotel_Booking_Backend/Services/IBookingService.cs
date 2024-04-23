using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;

namespace Hotel_Booking_Backend.Services;

public interface IBookingService
{
    Task<IEnumerable<Booking>> GetAllBookings();
    Task<IEnumerable<Booking>> GetAllBookingsByHotelId(int hotelId);
    Task<Booking> GetBookingById(int id);
    Task<Booking> CreateBooking(Booking booking);
    Task UpdateBooking(Booking booking);
    Task DeleteBooking(int id);
}

