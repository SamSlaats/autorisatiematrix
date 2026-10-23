# Ontwerp — Autorisatiematrix

Leerproject (C#/.NET) om een autorisatiematrix overzichtelijk te tonen, te bewerken en door te voeren naar Microsoft Entra ID en on-prem Active Directory. Dit document legt de beslissingen vast uit de ontwerpsessie van 23 oktober 2026. Elk issue in deze repo is hiervan afgeleid.

## Doel

- **Leerproject**, geen product. Bruikbaarheid voor klanten is geen meetlat; begrip van de code wel.
- Bewust eigen rechtenlogica in plaats van Entra ID Governance (access packages). De app stuurt wel bestaande mechanismen aan (groepen), maar concurreert er niet mee.

## Model

| Begrip | Betekenis |
|---|---|
| **Medewerker** | Een ingeschakeld medewerkersaccount binnen de afgebakende scope. Geen gasten, serviceaccounts of uitgeschakelde accounts. |
| **Recht** | Altijd een beveiligingsgroep. Entra: naamconventie `AUTH-`. AD: aparte OU. Licenties en NTFS-rechten lopen via die groepen. |
| **Rol** | Een functie. De matrix is **rol × recht**. De functie is leidend. |
| **Roltoewijzing** | Een medewerker krijgt handmatig één of meer rollen (v1). |
| **Uitzondering** | Alleen **toevoegend**. Verplicht: reden, eigenaar, vervaldatum. Zichtbaar anders in de matrix. |

**Effectieve rechten** = vereniging van alle rechten uit de rollen van een medewerker + zijn geldige (niet-verlopen) uitzonderingen.

Alleen **direct lidmaatschap** van gebruikers telt. Geneste groepen binnen beheerde groepen zijn een afwijking.

## Gedrag

1. De matrix is de **gewenste toestand**.
2. **Vergelijken** (v1: handmatig, met een knop) levert een verschillenoverzicht: toe te voegen, in te trekken, afwijkingen.
3. De beheerder **keurt goed**, daarna wordt **per actie** doorgevoerd en gelogd. Mislukte acties zijn zichtbaar; opnieuw draaien is veilig omdat de volgende vergelijking alleen toont wat nog ontbreekt. Geen terugdraaipogingen.
4. **Afwijkingen** (rechten die niet uit de matrix volgen) worden nooit automatisch ingetrokken. De beheerder kiest: intrekken of vastleggen als uitzondering.
5. **Verlopen uitzonderingen** verschijnen in het verschillenoverzicht als "wordt ingetrokken".

## Hybride (Entra + AD)

- Lab met AD DS en **Cloud Sync** naar Entra.
- Per groep wordt bepaald waar de **bron van gezag** ligt. Kernregel: *schrijf naar de bron van gezag, nooit naar een kopie.*
- Gesynchroniseerde groepen worden **alleen met AD vergeleken** (Entra loopt achter tot de volgende synchronisatieronde).
- Volgorde van bouwen: eerst Entra volledig werkend, daarna AD als tweede doelsysteem.

## Techniek

- Eén ASP.NET Core-app met **Blazor Server**, draait in het VMware-lab (tijdens de Entra-fase lokaal).
- Centraal ontwerpbesluit: interface **`IDirectoryTarget`** met `EntraTarget` en `AdTarget`.
- Entra via **Microsoft Graph SDK**, application permissions: `GroupMember.ReadWrite.All`, `User.Read.All`. Certificaat of user-secrets, nooit secrets in de repo.
- AD via **`System.DirectoryServices.Protocols`** (LDAP), serviceaccount met gedelegeerde rechten op alleen de AUTH-OU.
- Inloggen op de app via **Entra ID (OpenID Connect)** met app-rol `Matrixbeheerder`. Geen vier-ogenprincipe in v1.
- **EF Core + SQLite**, plus een **onveranderlijk auditlog** van matrixwijzigingen én doorgevoerde acties (wie, wanneer, wat, resultaat).
- Testen **uitsluitend** in een eigen testtenant en het lab. Nooit in een tenant van een werkgever, stagebedrijf of Illuvex.

## Buiten v1 (backlog)

1. **Periodieke vergelijking** (`BackgroundService`, alleen melden) — eerste prioriteit voor v2.
2. Rollen afleiden uit AD-attributen (indiensttreding, functiewissel, uitdiensttreding).
3. Controle: uitgeschakelde accounts die nog lid zijn van groepen.
4. Eventueel: webapp in de cloud met een losse on-prem agent.

## Werkwijze: samen bouwen

Elk issue is een stap in een leerroute. Per issue:

- Claude legt eerst het concept uit.
- Sam schrijft de kleinere, leerzame stukken zelf.
- Claude schrijft de rest in kleine stappen die Sam leest en terug uitlegt.
- Een issue is pas klaar als Sam kan uitleggen wat de code doet en waarom.
