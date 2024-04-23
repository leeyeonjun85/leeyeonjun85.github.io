using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_Backend.DAO;

public class HotelDAO : IHotelDAO
{
    private readonly HotelBookingContext _context;

    public HotelDAO(HotelBookingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Hotel>> GetAllHotels()
    {
        // Logic to retrieve all hotels from the database
        return await _context.Hotels.ToListAsync();
    }

    public async Task<Hotel> GetHotelById(int id)
    {
        // Logic to retrieve a hotel by ID from the database
        return await _context.Hotels.FindAsync(id);
    }

    public async Task<Hotel> CreateHotel(Hotel hotel)
    {
        // Logic to add a new hotel to the database
        System.Console.WriteLine("____`````____");
        _context.Hotels.Add(hotel);
        await _context.SaveChangesAsync();
        return hotel;
    }

    public async Task UpdateHotel(Hotel hotel)
    {
        // Logic to update a hotel in the database
        _context.Entry(hotel).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHotel(int id)
    {
        // Logic to delete a hotel from the database
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel != null)
        {
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

        }
    }
}
