namespace GBE.Services;

public interface IRemoteFileService
{
    Task<Stream> Fetch(string url);
}
