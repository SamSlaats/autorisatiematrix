using Autorisatiematrix.Domain;
using Shouldly;

namespace Autorisatiematrix.Tests;

public class UitzonderingTests
{
    [Fact]
    public void Uitzondering_ZonderReden_KanNietWordenAangemaakt()
    {
        // Voorbereiden
        var recht = new Recht("AUTH-Boekhouding");
        var vervaldatum = new DateOnly(2026, 12, 31);

        // Uitvoeren en controleren
        Should.Throw<ArgumentException>(() =>
            new Uitzondering(recht, reden:"", eigenaar: "Kevin Smit", vervaldatum));
    }
    [Fact]
    public void Uitzondering_ZonderEigenaar_KanNietWordenAangemaakt()
    {
        // voorbereiden
        var recht = new Recht("AUTH-Boekhouding");
        var vervaldatum = new DateOnly(2026, 12, 31);

        // Uitvoeren en controleren
        Should.Throw<ArgumentException>(() =>
            new Uitzondering(recht, reden:"test", eigenaar: "  ", vervaldatum));
    }
    [Fact]
    public void Uitzondering_ZonderVervalDatum_KanNietWordenAangemaakt()
    {
        // Voorbereiden
        var recht = new Recht("AUTH-Boekhouding");
        var vervaldatum = default(DateOnly);

        // Uitvoeren en controleren
        Should.Throw<ArgumentException>(() =>
            new Uitzondering(recht, reden:"test", eigenaar: "Kevin Smit", vervaldatum));
    }
}