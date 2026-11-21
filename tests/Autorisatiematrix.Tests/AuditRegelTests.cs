using Autorisatiematrix.Domain;
using Shouldly;

namespace Autorisatiematrix.Tests;

public class AuditRegelTests
{
    [Fact]
    public void AuditRegel_ZonderReden_KanNietWordenAangemaakt()
    {
        // Voorbereiden
        var tijdstip = new DateTime(2026, 11, 21, 19, 30, 0, DateTimeKind.Utc);
        var soortWijziging = SoortWijziging.RolAangemaakt;
        var onderwerpCategorie = OnderwerpSoort.Rol;
        var onderwerpId = Guid.NewGuid();
        var onderwerpNaam = "Planner";
        var doorId = Guid.NewGuid();
        var doorNaam = "Kevin Smit";
        string? voor = null;
        var na = "AUTH-TMS-Gebruiker, AUTH-TMS-Planner";

        // Uitvoeren en controleren
        Should.Throw<ArgumentException>(() =>
            new AuditRegel(tijdstip, soortWijziging, onderwerpCategorie, onderwerpId, onderwerpNaam, doorId, doorNaam, voor, na, reden:""));
    }
    [Fact]
    public void AuditRegel_MetGeldigeWaarden_KanWordenAangemaakt()
    {
        // Voorbereiden
        var tijdstip = new DateTime(2026, 11, 21, 19, 30, 0, DateTimeKind.Utc);
        var soortWijziging = SoortWijziging.RolAangemaakt;
        var onderwerpCategorie = OnderwerpSoort.Rol;
        var onderwerpId = Guid.NewGuid();
        var onderwerpNaam = "Planner";
        var doorId = Guid.NewGuid();
        var doorNaam = "Kevin Smit";
        string? voor = null;
        var na = "AUTH-TMS-Gebruiker, AUTH-TMS-Planner";
        var reden = "Test";

        // Uitvoeren en controleren
        Should.NotThrow(() =>
            new AuditRegel(tijdstip, soortWijziging, onderwerpCategorie, onderwerpId, onderwerpNaam, doorId, doorNaam, voor, na, reden));
    }
    [Fact]
    public void AuditRegel_MetTijdstipNietInUtc_KanNietWordenAangemaakt()
    {
        // Voorbereiden
        var tijdstip = new DateTime(2026, 11, 21, 19, 30, 0, DateTimeKind.Local);
        var soortWijziging = SoortWijziging.RolAangemaakt;
        var onderwerpCategorie = OnderwerpSoort.Rol;
        var onderwerpId = Guid.NewGuid();
        var onderwerpNaam = "Planner";
        var doorId = Guid.NewGuid();
        var doorNaam = "Kevin Smit";
        string? voor = null;
        var na = "AUTH-TMS-Gebruiker, AUTH-TMS-Planner";
        var reden = "Test";

        // Uitvoeren en controleren
        Should.Throw<ArgumentException>(() =>
            new AuditRegel(tijdstip, soortWijziging, onderwerpCategorie, onderwerpId, onderwerpNaam, doorId, doorNaam, voor, na, reden));
    }
}