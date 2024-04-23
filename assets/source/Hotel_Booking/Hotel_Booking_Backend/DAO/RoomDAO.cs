using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.DAO;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_Backend.DAO;

public class RoomDAO :IRoomDAO
{
    private readonly HotelBookingContext _context;

    public RoomDAO(HotelBookingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Room>> GetRoomByHotelIdAsync(int hotelId)
    {
        // Logic to retrieve all rooms from the database
        return await _context.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();
    }

    public async Task<Room> GetRoomByHotelIdAndRoomId(int hotelId, int roomId)
    {
        // Logic to retrieve rooms by hotel ID from the database
        Room? room = await _context.Rooms.FirstOrDefaultAsync(r => r.HotelId == hotelId && r.Id == roomId);
        return room;
    }

    public async Task<Room> CreateRoom(Room room)
    {
        // Logic to add a new room to the database
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task UpdateRoom(Room room)
    {
        // Logic to update a room in the database
        _context.Entry(room).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRoom(int hotelId, int roomId)
    {
        // Logic to delete a room from the database
        var room = await _context.Rooms.FirstOrDefaultAsync(r => r.HotelId == hotelId && r.Id == roomId);
        if (room != null)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
