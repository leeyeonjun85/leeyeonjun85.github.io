using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace Hotel_Booking_Backend.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    // Typically you wouldn't store the password directly, 
    // but would store a hash of the password.
    // This is just a simple example.
    [Required]
    public string Password { get; set; }

    // Navigation properties
    public virtual ICollection<Booking>? Bookings { get; } = new List<Booking>();

}


