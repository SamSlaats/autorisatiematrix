using Autorisatiematrix.Domain;
using Shouldly;

namespace Autorisatiematrix.Tests;

public class MedewerkerTests
{
    [Fact]
    public void EffectieveRechtenOp_MetRolPlanner_GeeftRechtenVanPlanner()
    {
        // Voorbereiden
        var planner = new Rol("Planner", new[] { new Recht("AUTH-TMS-Gebruiker"), new Recht("AUTH-TMS-Planner") });
        var lisa = new Medewerker("Lisa de Vries");
        lisa.WijRolToe(planner);
        var vandaag = new DateOnly(2026, 11, 13);
        
        // Uitvoeren
        var rechten = lisa.EffectieveRechtenOp(vandaag);

        // Controleren
        rechten.ShouldBe(new[] { new Recht("AUTH-TMS-Planner"), new Recht("AUTH-TMS-Gebruiker") }, ignoreOrder: true);
    }

    [Fact]
    public void Medewerker_ZonderNaam_KanNietWordenAangemaakt()
    {
        //Uitvoeren en Controleren
        Should.Throw<ArgumentException>(() => new Medewerker(""));
    }
}