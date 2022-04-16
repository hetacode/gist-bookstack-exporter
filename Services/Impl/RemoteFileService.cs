namespace GBE.Services.Impl;

public class RemoteFileService : IRemoteFileService
{
    public Task<Stream> Fetch(string url)
    {
        HttpClient http = new();
        return http.GetStreamAsync(url);
    }
}
