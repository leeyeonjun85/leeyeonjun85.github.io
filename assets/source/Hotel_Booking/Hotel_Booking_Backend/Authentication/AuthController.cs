using System;
using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Hotel_Booking_Backend.Authentication;


[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    // This APi is used to generate JWT Token for Alex
    private readonly IConfiguration _configuration;
    private readonly IAuthUserService _userService;
    public AuthController(IConfiguration configuration, IAuthUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost(nameof(Auth))]
    public IActionResult Auth([FromBody] LoginModel data)
    {
        bool isValid = _userService.IsValidUserInformation(data);
        if (isValid)
        {
            var tokenString = GenerateJwtToken(data.UserName);
            return Ok(new { Token = tokenString, Message = "Success" });
        }
        return BadRequest("Please pass the valid Username and Password");
    }
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet(nameof(GetResult))]
    public IActionResult GetResult()
    {
        return Ok("API Validated");
    }

    /// <summary>
    /// Generate JWT Token after successful login.
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    ///

    private string GenerateJwtToken(string userName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", userName), new Claim(ClaimTypes.Role, "Admin"), new Claim(ClaimTypes.Name, userName) }),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        try
        {
            var a1 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IkFsZXgiLCJyb2xlIjoiQWRtaW4iLCJ1bmlxdWVfbmFtZSI6IkFsZXgiLCJuYmYiOjE3MTM1MDAyNjcsImV4cCI6MTcxMzUwMzg0NiwiaWF0IjoxNzEzNTAwMjY3LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDg3IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo3MDg3In0.M5q4eMPQu1xDElmXI9Dw4j2JpQvQ3zR_WGNvPgW26Ec";
            JwtSecurityToken jwtSecurityToken = tokenHandler.ReadJwtToken(a1);
        }
        catch (Exception e)
        {
            var a2 = e.Message;
        }
    
        return tokenHandler.WriteToken(token);
    }
}



