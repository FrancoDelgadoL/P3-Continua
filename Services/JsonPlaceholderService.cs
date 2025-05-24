using System.Net.Http.Json;
using P3_Continua.Models;

namespace P3_Continua.Services
{
    public class JsonPlaceholderService
    {
        private readonly HttpClient _httpClient;

        public JsonPlaceholderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var posts = await _httpClient.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
            return posts ?? new List<Post>();
        }
        public async Task<User?> GetUserAsync(int userId)
        {
        return await _httpClient.GetFromJsonAsync<User>($"https://jsonplaceholder.typicode.com/users/{userId}");
        }

        public async Task<List<Comment>> GetCommentsForPostAsync(int postId)
        {
        var comments = await _httpClient.GetFromJsonAsync<List<Comment>>($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
        return comments ?? new List<Comment>();
        }

        public async Task<Post?> GetPostAsync(int id)
        {
        return await _httpClient.GetFromJsonAsync<Post>($"https://jsonplaceholder.typicode.com/posts/{id}");
        }
    }
}