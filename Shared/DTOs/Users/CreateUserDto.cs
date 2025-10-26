
using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Users;
public class CreateUserDto
{
    public string? Username { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Password must be between 1 and 100 characters")]
    public required string Password { get; set; } //not good to send password without hashing back to client
}