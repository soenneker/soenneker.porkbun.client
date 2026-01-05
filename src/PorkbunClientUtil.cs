using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Porkbun.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Porkbun.Client;

/// <inheritdoc cref="IPorkbunClientUtil"/>
public sealed class PorkbunClientUtil : IPorkbunClientUtil
{
    private readonly IHttpClientCache _httpClientCache;

    private const string _httpClientName = nameof(PorkbunClientUtil);

    public PorkbunClientUtil(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        // No closure: static lambda with no state needed
        return _httpClientCache.Get(_httpClientName, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(_httpClientName);
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(_httpClientName);
    }
}