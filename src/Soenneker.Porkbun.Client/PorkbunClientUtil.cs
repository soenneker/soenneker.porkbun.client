using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.Porkbun.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Porkbun.Client;

public sealed class PorkbunClientUtil : IPorkbunClientUtil
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _configuration;
    private readonly string _cacheKey = $"{nameof(PorkbunClientUtil)}:{Guid.NewGuid():N}";

    public PorkbunClientUtil(IHttpClientCache httpClientCache, IConfiguration configuration)
    {
        _httpClientCache = httpClientCache;
        _configuration = configuration;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(_cacheKey, _configuration, static configuration => new HttpClientOptions
        {
            BaseAddress = new Uri(configuration["Porkbun:ClientBaseUrl"] ?? "https://api.porkbun.com/api/json/v3/"),
            DefaultRequestHeaders = new Dictionary<string, string>
            {
                ["X-API-Key"] = configuration.GetValueStrict<string>("Porkbun:ApiKey"),
                ["X-Secret-API-Key"] = configuration.GetValueStrict<string>("Porkbun:SecretApiKey")
            }
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(_cacheKey);
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(_cacheKey);
    }
}
