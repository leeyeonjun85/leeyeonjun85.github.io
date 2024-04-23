using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;

namespace Hotel_Booking_Backend.DAO;

public interface IHotelDAO
{
    Task<IEnumerable<Hotel>> GetAllHotels();
    Task<Hotel> GetHotelById(int id);
    Task<Hotel> CreateHotel(Hotel hotel);
    Task UpdateHotel(Hotel hotel);
    Task DeleteHotel(int id);

}