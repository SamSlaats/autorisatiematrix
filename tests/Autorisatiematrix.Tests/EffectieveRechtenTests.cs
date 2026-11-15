using Autorisatiematrix.Domain;
using Shouldly;

namespace Autorisatiematrix.Tests;

public class EffectieveRechtenTests
{
    [Fact]
    public void Bereken_ZondewrRollenEnUitzonderingen_GeeftGeenRechten()
    {
        // voorbereiden
        var rollen = new List<Rol>();
        var uitzonderingen = new List<Uitzondering>();
        var vandaag = new DateOnly(2026, 11, 13);

        // uitvoeren
        var rechten = EffectieveRechten.Bereken(rollen, uitzonderingen, vandaag);

        // controleren
        rechten.ShouldBeEmpty();
    }
    [Fact]
    public void Bereken_EenRolMetTweeRechten_GeeftDieTweeRechten()
    {
        // voorbereiden
        var planner = new Rol("Planner", new[] { new Recht("AUTH-TMS-Gebruiker"), new Recht("AUTH-TMS-Planner") });
        var rollen = new List<Rol> { planner };
        var uitzonderingen = new List<Uitzondering>();
        var vandaag = new DateOnly(2026, 11, 13);


        // uitvoeren
        var rechten = EffectieveRechten.Bereken(rollen, uitzonderingen, vandaag);

        // controleren
        rechten.ShouldBe(new[] { new Recht("AUTH-TMS-Gebruiker"), new Recht("AUTH-TMS-Planner") }, ignoreOrder: true);
    }
}