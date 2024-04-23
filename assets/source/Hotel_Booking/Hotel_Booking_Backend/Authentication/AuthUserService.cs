using System;
using Hotel_Booking_Backend.Models;

namespace Hotel_Booking_Backend.Authentication;

public class AuthUserService : IAuthUserService
{
    public string GetUserDetails()
    {
        return "Alex";
    }

    public bool IsValidUserInformation(LoginModel model)
    {
        if (model.UserName.Equals("leeyeonjun") && model.Password.Equals("12345678")) return true;
        else return false;
    }
}

