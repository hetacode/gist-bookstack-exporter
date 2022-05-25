namespace GBE.Models.Bookstack;

public record Shelf(int id, string name, string description, ICollection<Book> books);
