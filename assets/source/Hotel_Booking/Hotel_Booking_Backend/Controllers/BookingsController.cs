using System;
using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.DAO;
using Hotel_Booking_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Hotel_Booking_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    // GET: api/bookings
    [HttpGet]
    public async Task<IEnumerable<Booking>> GetBookings()
    {
        return await _bookingService.GetAllBookings();
    }

    // GET: api/bookings/{id}
    [HttpGet("{id}")]
    public ActionResult<Booking> GetBooking(int id)
    {
        var booking = _bookingService.GetAllBookingsByHotelId(id);

        if (booking == null)
        {
            return NotFound();
        }

        return Ok(booking);
    }

    // POST: api/bookings
    [HttpPost]
    public ActionResult<Booking> PostBooking(Booking booking)
    {
        _bookingService.CreateBooking(booking);

        return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
    }

    // PUT: api/bookings/{id}
    [HttpPut("{id}")]
    public IActionResult PutBooking(int id, Booking booking)
    {
        if (id != booking.Id)
        {
            return BadRequest();
        }

        _bookingService.UpdateBooking(booking);

        return NoContent();
    }

    // DELETE: api/bookings/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteBooking(int id)
    {
        _bookingService.DeleteBooking(id);

        return NoContent();
    }
}
