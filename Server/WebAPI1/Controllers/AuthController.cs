using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;
using Shared.DTOs.Auth;
using Shared.DTOs.Comments;
using Shared.DTOs.Users;
using Models;

[ApiController]
[Route("auth")]

public class AuthController : ControllerBase
{
    private readonly IUserRepository userRepository;

    public AuthController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginRequestDto request)
    {
        User user = await userRepository.GetByUsernameAsync(request.Username);

        if (user == null || user.Password != request.Password)
        {
            return Unauthorized("Unauthorized: Invalid username or password.");
        }

        UserDto responseDto = new()
        {
            Id = user.Id,
            Username = user.Username,
        };

        return Ok(responseDto);
    }

    
}

