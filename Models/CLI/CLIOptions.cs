using CommandLine;

namespace GBE.Models.CLI;

public class CLIOptions
{
    [Option("tokenId", Required = true, HelpText = "Bookstack - api token id")]
    public string? BookstackTokenId { get; set; }

    [Option("tokenSecret", Required = true, HelpText = "Bookstack - api token secret")]
    public string? BookstackTokenSecret { get; set; }

    [Option("url", Required = true, HelpText = "Bookstack - service url")]
    public string? BookstackUrl { get; set; }

    [Option("book", Required = true, HelpText = "Bookstack - book name (if not exists - create)")]
    public string? BookstackBookName { get; set; }

    [Option("gist", Required = true, HelpText = "GitHub Gist id")]
    public string? GistId { get; set; }

}
