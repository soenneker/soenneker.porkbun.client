using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Porkbun.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Porkbun.Client;

/// <inheritdoc cref="IPorkbunClientUtil"/>
public class PorkbunClientUtil : IPorkbunClientUtil
{
    private readonly IHttpClientCache _httpClientCache;

    public PorkbunClientUtil(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(PorkbunClientUtil), () => null, cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _httpClientCache.RemoveSync(nameof(PorkbunClientUtil));
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _httpClientCache.Remove(nameof(PorkbunClientUtil));
    }
}