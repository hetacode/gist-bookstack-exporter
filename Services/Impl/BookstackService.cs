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

    public async Task<ICollection<Book>> GetBooks()
    {
        var response = await http.GetAsync($"/api/books");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<DataResult<ICollection<Book>>>(content);

        return result?.data ?? new List<Book>();
    }

    public async Task<ICollection<Shelf>> GetShelves()
    {
        var response = await http.GetAsync("/api/shelves");
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<DataResult<ICollection<Shelf>>>(content);

        return result?.data ?? new List<Shelf>();
    }

    public async Task<Shelf> CreateShelf(string name, string description)
    {
        var req = new
        {
            name = name,
            description = description
        };
        var json = JsonSerializer.Serialize(req);
        var response = await http.PostAsync("/api/shelf", new StringContent(json));
        var resultBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Shelf>(resultBody);

        return result;
    }


    public async Task<Book> CreateBook(string name, string description)
    {
        var req = new
        {
            name = name,
            description = description
        };
        var jsonBook = JsonSerializer.Serialize(req);
        var response = await http.PostAsync("/api/books", new StringContent(jsonBook, System.Text.Encoding.UTF8, "application/json"));
        var resultBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Book: " + resultBody);
        var resultBook = JsonSerializer.Deserialize<Book>(resultBody);


        return resultBook;
    }

    public async Task CreatePage(int bookId, string title, string content)
    {
        var req = new
        {
            book_id = bookId,
            name = title,
            markdown = content
        };

        var jsonPage = JsonSerializer.Serialize(req);
        var response = await http.PostAsync("/api/pages", new StringContent(jsonPage, System.Text.Encoding.UTF8, "application/json"));
        Console.WriteLine("Page response HTTP status: " + response.StatusCode);
    }

    record DataResult<T>(T data);
    record BooksResult(ICollection<Book> books);
}
