# Werkafspraken voor Claude

Dit is Sams leerproject. Het doel is dat Sam de code begrijpt, niet dat de app snel af is.
Ontwerpbeslissingen staan in [docs/ontwerp.md](docs/ontwerp.md), de leerroute in de issues
(milestones M0–M7, v2). Werk in het Nederlands.

## Samen bouwen

- Claude legt elk nieuw begrip uit voordat het in de code komt.
- Sam schrijft de kleinere stukken zelf, vooral waar al een voorbeeld in de code staat.
  Claude geeft dan het patroon en aanwijzingen, niet de kant-en-klare regel.
- Nieuwe of lastige code schrijft Claude in kleine stappen. Sam leest die en legt hem uit.
- Een issue is pas klaar als Sam kan uitleggen wat de code doet en waarom.
- Vragen die Sam moet beantwoorden staan apart en vetgedrukt:
  `> **Vraag:** ...`. Opdrachten op dezelfde manier: `> **Opdracht:** ...`.
  Nooit een vraag verstoppen aan het eind van een alinea.
- Claude is een kritische sparringpartner: onjuiste uitleg direct verbeteren, een zwak
  argument benoemen, eigen fouten eerlijk toegeven. Niet meegaan om het gezellig te houden.
- Laat Sam eerst voorspellen wat een build of test gaat zeggen, en daarna pas draaien.

## Testen (TDD)

- Rood, groen, refactor. Eerst een test die faalt om de goede reden.
- Een groene test telt pas als je hebt gezien dat hij kan falen: code of test tijdelijk
  slopen, rood zien, terugzetten.
- Randwaarden testen. Een nieuwe test toevoegen, nooit een bestaande vervangen.
- Na elke merge: kijk naar het **aantal** tests in CI, niet alleen naar groen.

## Git

- Een branch per issue (`<nummer>-<onderwerp>`), PR naar `main` met `Closes #<nummer>`,
  merge commit, daarna de branch verwijderen (op GitHub en lokaal).
- Sam commit en pusht de code zelf. Claude pusht geen code.
- Na `git add` altijd `git status` om te zien wat er echt in de commit gaat.
- Meerregelige commitberichten met meerdere `-m`, geen aanhalingstekens binnen het bericht.
- Een migratie die op `main` staat, wordt nooit herschreven: dan komt er een nieuwe bovenop.

## Issues en documentatie

- Claude beheert de issues: vinkt punten af en plaatst een bewijscommentaar, **alleen** op
  basis van uitvoer die Sam heeft laten zien. Niets verzinnen of aanvullen.
- Het project wordt gedocumenteerd op de portfoliosite (repo `SamSlaats/SamSlaats.github.io`,
  map `src/content/docs/autorisatiematrix/`). Volg daar `WERKLIJST.md`. Kort:
  Claude mag `bouwlog-*.md`, `beslissingen.md` en `storingen.md` zelf pushen, op basis van
  Sams keuzes en uitvoer. Een nieuwe bouwlog begint met `draft: true` tot Sam hem heeft
  nagelezen. Andere bestanden alleen met Sams toestemming.
- Een bouwlog per milestone, geschreven als de milestone af is.

## Veiligheid

- Tenant-ID's, client-ID's, `onmicrosoft.com`-domeinen, e-mailadressen en secrets komen nooit
  op de site, in issues, in Git of in de chat.
- Secrets staan in `dotnet user-secrets`. Invoeren met `read -rs` in een variabele, niet in
  de shellgeschiedenis. Controle dat een secret niet in Git staat:
  `git log -p --all | grep -cF "$S"` (moet `0` zijn).
- Testen alleen in de eigen testtenant en het lab.

## Omgeving en opbouw

- WSL2 (Ubuntu) met VS Code; op Windows blokkeert Smart App Control zelfgebouwde DLL's.
- .NET 10 (`global.json`), xUnit v3 met Microsoft.Testing.Platform, Shouldly.
- Lagen: Domain (geen referenties) ← Application ← Infrastructure ← Web.
  `Tests` kent Domain en Application, `IntegrationTests` kent Infrastructure.
- Het domein weet niets van EF Core. Configuratie staat in Infrastructure
  (`IEntityTypeConfiguration`); de enige concessies in het domein zijn een `Id` en private
  constructors voor EF.
- Commando's vanuit de root: `dotnet build`, `dotnet test`,
  `dotnet ef migrations add <Naam> --project src/Autorisatiematrix.Infrastructure`.
- Packages altijd op een versie die bij net10.0 past (EF Core 10.0.x), anders NU1202.

## Terugkerende valkuilen

- Typfouten in namen (`ShouldBe`, `Rechten`, `Infrastructure`): laat IntelliSense aanvullen
  en draai `dotnet build` voordat je code doorstuurt.
- Bij kopiëren en plakken elke naam nalopen: klasse, type tussen `< >`, tabel.
- `Should.Throw` met de aanroep binnen de lambda.
