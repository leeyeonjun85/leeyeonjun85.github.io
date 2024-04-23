using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.DAO;

namespace Hotel_Booking_Backend.Services;

public class RoomService : IRoomService
{
    private readonly IRoomDAO _roomDAO;

    public RoomService(IRoomDAO roomDAO)
    {
        _roomDAO = roomDAO;
    }

    //public async Task<IEnumerable<Room>> GetAllRooms()
    //{
    //    return await _roomDAO.GetAllRooms();
    //}

    public async Task<IEnumerable<Room>> GetRoomsByHotelId(int hotelId)
    {
        return await _roomDAO.GetRoomByHotelIdAsync(hotelId);
    }

    public async Task<Room> GetRoomByHotelIdAndRoomId(int hotelId,int roomid)
    {
        return await _roomDAO.GetRoomByHotelIdAndRoomId(hotelId, roomid);
    }

    public async Task<Room> AddRoomToHotel(Room room)
    {
        return await _roomDAO.CreateRoom(room);
    }

    public async Task UpdateRoom(Room room)
    {
        await _roomDAO.UpdateRoom(room);
    }

    public async Task DeleteRoom(int hotelId, int roomId)
    {
        await _roomDAO.DeleteRoom(hotelId, roomId);
    }
}
