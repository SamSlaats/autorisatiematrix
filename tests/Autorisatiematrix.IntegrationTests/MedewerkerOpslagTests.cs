using Autorisatiematrix.Domain;
using Autorisatiematrix.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace Autorisatiematrix.IntegrationTests;

public class MedewerkerOpslagTests
{
    [Fact]
    public void Medewerker_MetRolEnUitzondering_HeeftNaTerugladenDezelfdeEffectieveRechten()
    {
        // Voorbereiden
        using var verbinding = new SqliteConnection("DataSource=:memory:");
        verbinding.Open();
        var opties = new DbContextOptionsBuilder<AutorisatiematrixDbContext>()
            .UseSqlite(verbinding)
            .Options;
        var vandaag = new DateOnly(2026, 11, 19);

        using (var context = new AutorisatiematrixDbContext(opties))
        {
            context.Database.Migrate();

            var planner = new Rol("Planner", new[] { new Recht("AUTH-TMS-Gebruiker"), new Recht("AUTH-TMS-Planner") });
            var lisa = new Medewerker("Lisa de Vries");
            lisa.WijsRolToe(planner);
            lisa.VoegUitzonderingToe(new Uitzondering(
                new Recht("AUTH-Boekhouding"),
                reden: "Helpt Financiën bij de jaarafsluiting",
                eigenaar: "Kevin Smit",
                vervaldatum: new DateOnly(2026, 12, 31)));

            context.Medewerkers.Add(lisa);
            context.SaveChanges();
        }

        // Uitvoeren
        using var nieuweContext = new AutorisatiematrixDbContext(opties);
        var terugladen = nieuweContext.Medewerkers
            .Include(m => m.Rollen)
            .Include(m => m.Uitzonderingen)
            .Single(m => m.Naam == "Lisa de Vries");
        
        // Controleren
        terugladen.EffectieveRechtenOp(vandaag).ShouldBe(
            new[] { new Recht("AUTH-TMS-Gebruiker"), new Recht("AUTH-TMS-Planner"), new Recht("AUTH-Boekhouding") },
            ignoreOrder: true);
    }
}