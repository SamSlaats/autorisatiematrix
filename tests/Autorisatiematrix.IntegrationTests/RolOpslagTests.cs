using Autorisatiematrix.Domain;
using Autorisatiematrix.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace Autorisatiematrix.IntegrationTests;

public class RolOpslagTests
{
    [Fact]
    public void Rol_MetRechten_KanWordenOpgeslagenEnTeruggeladen()
    {
        // Voorbereiden: een database die alleen in het geheugen bestaat
        using var verbinding = new SqliteConnection("DataSource=:memory:");
        verbinding.Open();
        var opties = new DbContextOptionsBuilder<AutorisatiematrixDbContext>()
            .UseSqlite(verbinding)
            .Options;

        using (var context = new AutorisatiematrixDbContext(opties))
        {
            context.Database.Migrate();
            context.Rollen.Add(new Rol("Planner", new[] { new Recht("AUTH-TMS-Gebruiker"), new Recht("AUTH-TMS-Planner") }));
            context.SaveChanges();
        }

        // Uitvoeren: terugladen met een nieuwe context
        using var nieuweContext = new AutorisatiematrixDbContext(opties);
        var planner = nieuweContext.Rollen.Single(r => r.Naam == "Planner");

        // Controleren
        planner.Rechten.ShouldBe(new[] { new Recht("AUTH-TMS-Gebruiker"), new Recht("AUTH-TMS-Planner") }, ignoreOrder: true);
    }
}