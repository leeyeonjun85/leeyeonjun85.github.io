using System.ComponentModel.DataAnnotations;

namespace Hotel_Booking_Backend.Models;

public class Room
{
    public int Id { get; set; }
    public int HotelId { get; set; }
        
    [Required]
    [MaxLength(10)]
    public string RoomNumber { get; set; }
        
    [Required]
    [Range(0, double.MaxValue)]
    public double PricePerNight { get; set; }
    // Additional properties specific to a room

    // Navigation properties
    public virtual Hotel? Hotel { get; set; }
    public virtual Booking? Booking { get; set; }

}

