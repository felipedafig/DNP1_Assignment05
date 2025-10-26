using System.Net.Http.Json;
using System.Text.Json;
using Shared.DTOs.Posts;

namespace BlazorApp.Services;
public class HttpPostService : IPostService
{
    private readonly HttpClient client;
    public HttpPostService(HttpClient client) { this.client = client; }

    public async Task<PostDto> AddPostAsync(CreatePostDto request)
    {
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync("posts", request);
        string response = await httpResponse.Content.ReadAsStringAsync();

        if (!httpResponse.IsSuccessStatusCode)
        { throw new Exception(response); }

        return JsonSerializer.Deserialize<PostDto>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    public async Task<List<PostDto>> GetManyPostsAsync()
    {
        HttpResponseMessage httpResponse = await client.GetAsync("posts");
        string response = await httpResponse.Content.ReadAsStringAsync();

        if (!httpResponse.IsSuccessStatusCode)
        { throw new Exception(response); }

        return JsonSerializer.Deserialize<List<PostDto>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    public async Task<PostDto> GetSinglePostAsync(int id)
    {
        HttpResponseMessage httpResponse = await client.GetAsync($"posts/{id}");
        string response = await httpResponse.Content.ReadAsStringAsync();

        if (!httpResponse.IsSuccessStatusCode)
        { throw new Exception(response); }

        return JsonSerializer.Deserialize<PostDto>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}