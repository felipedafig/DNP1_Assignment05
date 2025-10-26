using System.Text.Json;
using Shared.DTOs.Comments;

namespace BlazorApp.Services;

public class HttpCommentService : ICommentService
{
    private readonly HttpClient client;
    
    public HttpCommentService(HttpClient client) 
    { 
        this.client = client; 
    }
    
    public async Task<List<CommentDto>> GetCommentsByPostIdAsync(int postId)
    {
        HttpResponseMessage httpResponse = await client.GetAsync($"posts/{postId}/comments");
        string response = await httpResponse.Content.ReadAsStringAsync();

        if (!httpResponse.IsSuccessStatusCode)
        { throw new Exception(response); }

        return JsonSerializer.Deserialize<List<CommentDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    public async Task<CommentDto> AddCommentAsync(CreateCommentDto request, int postId)
    {
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync($"posts/{postId}/comments", request);
        string response = await httpResponse.Content.ReadAsStringAsync();

        if (!httpResponse.IsSuccessStatusCode)
        { throw new Exception(response); }

        return JsonSerializer.Deserialize<CommentDto>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}
