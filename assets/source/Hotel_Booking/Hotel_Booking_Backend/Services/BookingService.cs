using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.DAO;
using Hotel_Booking_Backend.Services;

namespace Hotel_Booking_Backend.Services;

public class BookingService : IBookingService {

    private readonly IBookingDAO _bookingDAO;

    public BookingService(IBookingDAO bookingDAO)
    {
        _bookingDAO = bookingDAO;
    }


    public async Task<IEnumerable<Booking>> GetAllBookings()
    {
        return await _bookingDAO.GetAllBookings();
    }

    public async Task<IEnumerable<Booking>> GetAllBookingsByHotelId(int hotelId)
    {
        return await _bookingDAO.GetAllBookings();
    }

    public async Task<Booking> GetBookingById(int id)
    {
        return await _bookingDAO.GetBookingById(id);
    }

    public async Task<Booking> CreateBooking(Booking booking)
    {
        return await _bookingDAO.CreateBooking(booking);
    }

    public async Task UpdateBooking(Booking booking)
    {
        await _bookingDAO.UpdateBooking(booking);
    }

    public async Task DeleteBooking(int id)
    {
        await _bookingDAO.DeleteBooking(id);
    }
}
