using GBE.Models.Bookstack;

namespace GBE.Services;

public interface IBookstackService
{
    Task<ICollection<Shelf>> GetShelves();
    Task<ICollection<Book>> GetBooks(int shelfId);
    Task SavePage(string title, string content);
}
