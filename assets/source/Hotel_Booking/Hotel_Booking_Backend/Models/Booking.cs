using System;

namespace Hotel_Booking_Backend.Models;

public class Booking
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public double TotalPrice { get; set; }
    public int IsPaid { get; set; }
    // Add any additional properties related to a booking

    // Navigation properties
    public virtual Room? Room { get; set; }
    public virtual User? User { get; set; }

}

