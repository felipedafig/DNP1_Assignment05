namespace BlazorApp.Services;
using Shared.DTOs.Comments;

public interface ICommentService
{
    Task<List<CommentDto>> GetCommentsByPostIdAsync(int postId);
    Task<CommentDto> AddCommentAsync(CreateCommentDto request, int postId);
}