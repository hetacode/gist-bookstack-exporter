// See https://aka.ms/new-console-template for more information
using System.Text;
using CommandLine;
using GBE.Models.CLI;
using GBE.Services.Impl;

RemoteFileService remoteFileService = new();
await Parser.Default.ParseArguments<CLIOptions>(args).WithParsedAsync<CLIOptions>(async o =>
{
    // 1. get gist data
    // and download files
    Console.WriteLine($"Fetch gist {o.GistId!} content");

    List<(string rawUrl, string filename, string content)> gistElements = new();
    var gistService = new GistService();
    var gistData = await gistService.GetGistData(o.GistId!);
    foreach (var f in gistData.files.ToList())
    {
        using var remoteFileStream = await remoteFileService.Fetch(f.Value.raw_url);
        using StreamReader sr = new(remoteFileStream);
        var fileContent = await sr.ReadToEndAsync();
        gistElements.Add((f.Value.raw_url, f.Value.filename, fileContent));
    }
    // 3. fetch bootstack shelves and check name with options property

    var bookService = new BookstackService(o.BookstackUrl!, o.BookstackTokenId!, o.BookstackTokenSecret!);
    // 4. fetch bootstack books and check name with options property
    var books = await bookService.GetBooks();
    books.ToList().ForEach(f => Console.WriteLine(f));
    var book = books.FirstOrDefault(f => f.name.ToLower() == o.BookstackBookName!.ToLower());

    if (book is null)
    {
        Console.WriteLine($"Create new book '{o.BookstackBookName}'");
        book = await bookService.CreateBook(o.BookstackBookName!, "A book with github gists");
    }

    // 6. save gist files content as page in bookstack book

    Console.WriteLine("Save gist content to Bookstack page");
    StringBuilder contentStringBuilder = new();
    gistElements.ForEach(ge =>
    {
        contentStringBuilder.Append($"### {ge.filename}");
        var content = ge switch
        {
            var element when element.filename.ToLower().EndsWith(".md") => ge.content,
            _ => $"```{ge.content}```"
        };
        contentStringBuilder.Append(content);
    });
    await bookService.CreatePage(book!.id, gistData.description, contentStringBuilder.ToString());

    Console.WriteLine("Done!");
});
