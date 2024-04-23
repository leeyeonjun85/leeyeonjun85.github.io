using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;

namespace Hotel_Booking_Backend.DAO;

public interface IRoomDAO
{
    Task<IEnumerable<Room>> GetRoomByHotelIdAsync(int hotelId);
    Task<Room> GetRoomByHotelIdAndRoomId(int hotelId, int roomId);
    Task<Room> CreateRoom(Room room);
    Task UpdateRoom(Room room);
    Task DeleteRoom(int hotelId, int roomId);

}