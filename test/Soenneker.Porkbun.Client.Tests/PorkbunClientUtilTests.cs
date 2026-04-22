using Soenneker.Porkbun.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Porkbun.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class PorkbunClientUtilTests : HostedUnitTest
{
    private readonly IPorkbunClientUtil _util;

    public PorkbunClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<IPorkbunClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
