using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Booking_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_Backend.DAO;

public class UserDAO : IUserDAO
{
    private readonly HotelBookingContext _context;

    public UserDAO(HotelBookingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        // Retrieve all users from the database
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        // Retrieve a user by their ID from the database
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateUser(User user)
    {
        // Add a new user to the database
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateUser(User user)
    {
        // Update a user in the database
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        // Delete a user from the database
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
