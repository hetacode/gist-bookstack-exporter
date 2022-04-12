namespace GBE.Models.Gist;

public record GistData(string html_url, string description, Dictionary<string, GistDataFile> files);

public record GistDataFile(string filename, string raw_url, string type);
