using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;

namespace Hotel_Booking_Backend.DAO;

public interface IBookingDAO
{
    Task<IEnumerable<Booking>> GetAllBookings();
    Task<IEnumerable<Booking>> GetAllBookingsByHotelId(int hotelId);
    Task<Booking> GetBookingById(int id);
    Task<Booking> CreateBooking(Booking booking);
    Task UpdateBooking(Booking booking);
    Task DeleteBooking(int id);

}
