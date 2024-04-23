using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.Services;

namespace User_Booking_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: /users/{userId}
    [HttpGet("{userId}")]
    public async Task<IEnumerable<User>> GetUserById(int userId)
    {
        return (IEnumerable<User>)await _userService.GetUserById(userId);
    }


    // POST: /users
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] User user)
    {
        var createdUser = await _userService.CreateUser(user);
        return CreatedAtAction(nameof(CreateUser), new { userId = createdUser.Id}, createdUser);
    }

    // PUT: /users/{userId}
    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, [FromBody] User user)
    {
        if (userId != user.Id)
        {
            return BadRequest("The provided userId does not match the user's Id.");
        }

        await _userService.UpdateUser(user);
        return NoContent();
    }

    // DELETE: /users/{userId}
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        await _userService.DeleteUser(userId);
        return NoContent();
    }
}
