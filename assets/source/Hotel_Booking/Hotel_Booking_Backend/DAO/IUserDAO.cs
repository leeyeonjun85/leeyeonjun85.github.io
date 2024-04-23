using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;

namespace Hotel_Booking_Backend.DAO;

public interface IUserDAO
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<User> CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);

}
