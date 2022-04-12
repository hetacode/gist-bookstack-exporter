using GBE.Models.Gist;

namespace GBE.Services;

public interface IGistService
{
    Task<GistData> GetGistData(string id);
}
