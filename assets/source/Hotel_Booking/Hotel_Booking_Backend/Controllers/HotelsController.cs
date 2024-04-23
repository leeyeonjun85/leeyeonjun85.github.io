using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.Services;

namespace Hotel_Booking_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    // GET: /hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hotel>>> GetAllHotels()
    {
        return Ok(await _hotelService.GetAllHotels());
    }

    // GET: /hotels/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Hotel>> GetHotelById(int id)
    {
        var hotel = await _hotelService.GetHotelById(id);
        if (hotel == null)
        {
            return NotFound();
        }
        return Ok(hotel);
    }

    // POST: /hotels
    [HttpPost]
    public async Task<ActionResult<Hotel>> CreateHotel([FromBody] Hotel hotel)
    {
        var createdHotel = await _hotelService.CreateHotel(hotel);
        return CreatedAtAction(nameof(GetHotelById), new { id = createdHotel.Id }, createdHotel);
    }

    // PUT: /hotels
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] Hotel hotel)
    {
        if (id != hotel.Id)
        {
            return BadRequest();
        }
        await _hotelService.UpdateHotel(hotel);
        return NoContent();
    }

    // DELETE: /hotels/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        await _hotelService.DeleteHotel(id);
        return NoContent();
    }
}

