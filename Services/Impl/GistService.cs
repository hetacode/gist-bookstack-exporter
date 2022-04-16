using System.Text.Json;
using GBE.Models.Gist;

namespace GBE.Services.Impl;

public class GistService : IGistService
{
    public async Task<GistData> GetGistData(string id)
    {
        HttpClient http = new();
        http.BaseAddress = new("https://api.github.com");
        http.DefaultRequestHeaders.Accept.Add(new ("application/vnd.github.v3+json"));
        http.DefaultRequestHeaders.UserAgent.Add(new("GBE-client", "0.1"));
        var rawJson = await http.GetStringAsync($"/gists/{id}");
        var result = JsonSerializer.Deserialize<GistData>(rawJson);
        return result;
    }
}
