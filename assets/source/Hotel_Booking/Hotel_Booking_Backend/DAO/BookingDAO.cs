using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_Backend.DAO;

public class BookingDAO : IBookingDAO
{
    private readonly HotelBookingContext _context;

    public BookingDAO(HotelBookingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetAllBookings()
    {
        // retrieve all bookings from the database
        return await _context.Bookings.ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetAllBookingsByHotelId(int hotelId)
    {
        // retrieve a booking by ID from the database
        return await _context.Bookings.Where(b => b.Room.HotelId == hotelId).ToListAsync();
    }

    public async Task<Booking> GetBookingById(int id)
    {
        // retrieve a booking by ID from the database
        return await _context.Bookings.FindAsync(id);;
    }

    public async Task<Booking> CreateBooking(Booking booking)
    {
        // add a new booking to the database
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task UpdateBooking(Booking booking)
    {
        // update a booking in the database
        _context.Entry(booking).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBooking(int id)
    {
        // delete a booking from the database
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}
