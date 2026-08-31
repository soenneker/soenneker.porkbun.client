[![](https://img.shields.io/nuget/v/soenneker.porkbun.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.porkbun.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.porkbun.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.porkbun.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.porkbun.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.porkbun.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.porkbun.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.porkbun.client/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Porkbun.Client

Provides a cached `HttpClient` configured for Porkbun's domain, DNS, SSL, pricing, and account APIs.

## Installation

```bash
dotnet add package Soenneker.Porkbun.Client
```

## Configuration

```json
{
  "Porkbun": {
    "ApiKey": "your-api-key",
    "SecretApiKey": "your-secret-api-key"
  }
}
```

The default base URL is `https://api.porkbun.com/api/json/v3/`. Override it with `Porkbun:ClientBaseUrl` when testing through a proxy or compatible endpoint.

## Usage

```csharp
using Soenneker.Porkbun.Client.Abstract;
using Soenneker.Porkbun.Client.Registrars;

services.AddPorkbunClientUtilAsSingleton();

IPorkbunClientUtil porkbun = serviceProvider
    .GetRequiredService<IPorkbunClientUtil>();

HttpClient client = await porkbun.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync(
    "pricing/get",
    cancellationToken);
response.EnsureSuccessStatusCode();
```

The client sends `X-API-Key` and `X-Secret-API-Key` on every request. Use an `Idempotency-Key` header for writes that may be retried, and use Porkbun's `dryRun` request field before billable or destructive operations when the endpoint supports it.

The provider owns the cached client. Scoped provider registrations use separate cache entries, so disposing one scope does not invalidate another scope's client.
