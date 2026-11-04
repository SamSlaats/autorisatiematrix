using Shouldly;

namespace Autorisatiematrix.Tests;

public class DummyTests
{
    [Fact]
    public void Optellen_TienPlusTwintig_GeeftDertig()
    {
        int getal1 = 10;
        int getal2 = 20;
        int verwachteUitkomst = 30;
        
        int uitkomst = getal1 + getal2;

        uitkomst.ShouldBe(verwachteUitkomst);
    }
}
