using GBE.Models.Bookstack;

namespace GBE.Services;

public interface IBookstackService
{
    Task<ICollection<Shelf>> GetShelves();
    Task<ICollection<Book>> GetBooks();
    Task<Shelf> CreateShelf(string name, string description);
    Task<Book> CreateBook(string name, string description);
    Task CreatePage(int bookId, string title, string content);
}
