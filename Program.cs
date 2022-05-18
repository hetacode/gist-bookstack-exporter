// See https://aka.ms/new-console-template for more information
using GBE.Services.Impl;

var bookstackTokenId = Environment.GetEnvironmentVariable("BOOKSTACK_TOKENID");
var bookstackTokenSecret = Environment.GetEnvironmentVariable("BOOKSTACK_TOKENSECRET");
var bookstackUrl = Environment.GetEnvironmentVariable("BOOKSTACK_URL");

var gistId = Environment.GetEnvironmentVariable("GIST_ID");

//var bookService = new BookstackService(bookstackUrl, bookstackTokenId, bookstackTokenSecret);
//foreach (var f in (await bookService.GetShelves()).ToList())
//{
//    Console.WriteLine(f);
//    (await bookService.GetBooks(f.id)).ToList().ForEach(fb => Console.WriteLine(fb));
//}
//
//var gistService = new GistService();
//var data = await gistService.GetGistData(gistId);
//Console.WriteLine(data);
//data.files.ToList().ForEach(f => Console.WriteLine(f.Value));

RemoteFileService remoteFileService = new();
using var remoteFileStream = await remoteFileService.Fetch("https://example.com");
using StreamReader sr = new(remoteFileStream);
var fileContent = await sr.ReadToEndAsync();
Console.WriteLine(fileContent);
