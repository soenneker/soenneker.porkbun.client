using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Porkbun.Client.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for Porkbun
/// </summary>
public interface IPorkbunClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
