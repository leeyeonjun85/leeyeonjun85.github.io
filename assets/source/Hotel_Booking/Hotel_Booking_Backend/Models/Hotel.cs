using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Hosting;

namespace Hotel_Booking_Backend.Models;

public class Hotel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    // Navigation properties
    public virtual ICollection<Room>? Rooms { get; } = new List<Room>();

}


