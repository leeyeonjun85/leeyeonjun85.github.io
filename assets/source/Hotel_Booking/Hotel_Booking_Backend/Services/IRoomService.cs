using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;

namespace Hotel_Booking_Backend.Services;

public interface IRoomService
{
    //Task<IEnumerable<Room>> GetAllRooms();
    Task<IEnumerable<Room>> GetRoomsByHotelId(int hotelId);
    Task<Room> GetRoomByHotelIdAndRoomId(int hotelId, int roomId);
    Task<Room> AddRoomToHotel(Room room);
    Task UpdateRoom(Room room);
    Task DeleteRoom(int hotelId, int roomId);
}

