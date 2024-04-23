using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.Services;

namespace Hotel_Booking_Backend.Controllers;

[ApiController]
[Route("api/[controller]/{hotelId}")]
public class RoomsController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomsController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    // GET: /hotels/{hotelId}/rooms
    [HttpGet]
    public async Task<IEnumerable<Room>> GetAllRoomsInOneHotel(int hotelId)
    {
        return await _roomService.GetRoomsByHotelId(hotelId);
    }

    // GET: /hotels/{hotelId}/rooms/{roomId}
    [HttpGet("{roomId}")]
    public async Task<Room> GetRoom(int hotelId, int roomId)
    {
        return await _roomService.GetRoomByHotelIdAndRoomId(hotelId, roomId);
    }

    // POST: /hotels/{hotelId}/rooms
    [HttpPost]
    public async Task<ActionResult<Room>> CreateRoom([FromBody] Room room)
    {
        var createdRoom = await _roomService.AddRoomToHotel(room);
        return CreatedAtAction(nameof(GetRoom), new { hotelId = createdRoom.HotelId, roomId = createdRoom.Id }, createdRoom);
    }

    // PUT: /hotels/{hotelId}/rooms/{roomId}
    [HttpPut("{roomId}")]
    public async Task<IActionResult> UpdateRoom(int hotelId, int roomId, [FromBody] Room room)
    {
        if (roomId != room.Id)
        {
            return BadRequest("The provided roomId does not match the room's Id.");
        }

        await _roomService.UpdateRoom(room);
        return NoContent();
    }

    // DELETE: /hotels/{hotelId}/rooms/{roomId}
    [HttpDelete("{roomId}")]
    public async Task<IActionResult> DeleteRoom(int hotelId, int roomId)
    {
        await _roomService.DeleteRoom(hotelId, roomId);
        return NoContent();
    }
}

