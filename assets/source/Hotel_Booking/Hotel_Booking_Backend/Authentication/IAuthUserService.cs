using System;
using Hotel_Booking_Backend.Models;

namespace Hotel_Booking_Backend.Authentication;

public interface IAuthUserService
{
    bool IsValidUserInformation(LoginModel model);
    String GetUserDetails();
}

