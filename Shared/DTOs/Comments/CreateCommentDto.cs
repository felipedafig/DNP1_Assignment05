
using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Comments;

public class CreateCommentDto
{
    [Required(ErrorMessage = "Comment body is required")]
    public string? Body { get; set; }
    
    [Required(ErrorMessage = "User ID is required")]
    public int UserId { get; set; }
}