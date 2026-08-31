using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Porkbun.Client.Abstract;

/// <summary>
/// Provides an authenticated HTTP client for Porkbun's JSON API.
/// </summary>
public interface IPorkbunClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached client owned by this provider.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
