using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;

namespace Hotel_Booking_Backend.Services;

public interface IHotelService
{
    Task<IEnumerable<Hotel>> GetAllHotels();
    Task<Hotel> GetHotelById(int id);
    Task<Hotel> CreateHotel(Hotel hotel);
    Task UpdateHotel(Hotel hotel);
    Task DeleteHotel(int id);
}
