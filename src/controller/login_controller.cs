using Microsoft.AspNetCore.Mvc;
using vertex.src.Data;
using Microsoft.EntityFrameworkCore;
using vertex.src.Models;

namespace vertex.src.controller
{
    [ApiController]
    [Route("api/usercontroller")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userRegisterDTO)
        {
            var isExist = await _context.Users.AnyAsync(x => x.Email == userRegisterDTO.email);
            if (isExist)
            {
                return BadRequest(new { success = false, message = "already registered" });
            }

            var newUser = new UserModel
            {
                Name = userRegisterDTO.name,
                Age = userRegisterDTO.age,
                Phone = userRegisterDTO.phone,
                Email = userRegisterDTO.email,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "User Register Successfully", data = newUser });
        }


        [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] UserLoginDTOs model)
{
    // Email exists? ✅
    var user = await _context.Users
        .FirstOrDefaultAsync(x => x.Email == model.email && x.Phone == model.phone);

    if (user == null)
    {
        return Unauthorized(new { success = false, message = "Invalid email or password" });
    }

    // Success response
    return Ok(new
    {
        success = true,
        message = "Login successful",
        token = "dummy-jwt-token-123",
        user = new
        {
            id = user.Id,
            name = user.Name,
            email = user.Email
        }
    });
}

    }
}