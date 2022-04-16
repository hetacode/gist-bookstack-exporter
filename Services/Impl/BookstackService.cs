using System.Text.Json;
using GBE.Models.Bookstack;

namespace GBE.Services.Impl;

public class BookstackService : IBookstackService
{
    private HttpClient http = new HttpClient();
    private string tokenId;
    private string tokenSecret;

    private string Token => $"{tokenId}:{tokenSecret}";

    public BookstackService(string serviceUrl, string tokenId, string tokenSecret)
    {
        http.BaseAddress = new Uri(serviceUrl);
        this.tokenSecret = tokenSecret;
        this.tokenId = tokenId;
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", Token);
    }

    public async Task<ICollection<Book>> GetBooks(int shelfId)
    {
        var response = await http.GetAsync($"/api/shelves/{shelfId}");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<BooksResult>(content);

        return result?.books ?? new List<Book>();
    }

    public async Task<ICollection<Shelf>> GetShelves()
    {
        var response = await http.GetAsync("/api/shelves");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<DataResult<ICollection<Shelf>>>(content);

        return result?.data ?? new List<Shelf>();
    }

    public Task SavePage(string title, string content)
    {
        throw new NotImplementedException();
    }

    record DataResult<T>(T data);
    record BooksResult(ICollection<Book> books);
}
