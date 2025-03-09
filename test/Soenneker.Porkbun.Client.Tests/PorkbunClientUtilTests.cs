using Soenneker.Porkbun.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Porkbun.Client.Tests;

[Collection("Collection")]
public class PorkbunClientUtilTests : FixturedUnitTest
{
    private readonly IPorkbunClientUtil _util;

    public PorkbunClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IPorkbunClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
