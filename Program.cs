// See https://aka.ms/new-console-template for more information
using GBE.Services;

var bookstackTokenId = Environment.GetEnvironmentVariable("BOOKSTACK_TOKENID");
var bookstackTokenSecret = Environment.GetEnvironmentVariable("BOOKSTACK_TOKENSECRET");
var bookstackUrl = Environment.GetEnvironmentVariable("BOOKSTACK_URL");

var bookService = new BookstackService(bookstackUrl, bookstackTokenId, bookstackTokenSecret);
foreach (var f in (await bookService.GetShelves()).ToList())
{
    Console.WriteLine(f);
    (await bookService.GetBooks(f.id)).ToList().ForEach(fb => Console.WriteLine(fb));
}



