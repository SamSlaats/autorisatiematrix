namespace Autorisatiematrix.Domain;

public sealed class AuditRegel
{
    public AuditRegel(DateTime tijdstip, SoortWijziging soortWijziging, OnderwerpSoort onderwerpCategorie, Guid onderwerpId, string onderwerpNaam, Guid doorId, string doorNaam, string? voor, string na, string reden)
    {
        if (tijdstip == default)
        {
            throw new ArgumentException("Een auditregel moet een geldig tijdstip hebben.", nameof(tijdstip));
        }
        if (tijdstip.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException("Een auditregel moet in de UTC tijdzone zitten.", nameof(tijdstip));
        }
        if (!Enum.IsDefined(soortWijziging))
        {
            throw new ArgumentException("Een auditregel moet een geldige soort wijziging hebben.", nameof(soortWijziging));
        }
        if (!Enum.IsDefined(onderwerpCategorie))
        {
            throw new ArgumentException("Een auditregel moet een geldige soort onderwerp hebben.", nameof(onderwerpCategorie));
        }
        if (onderwerpId == Guid.Empty)
        {
            throw new ArgumentException("Een auditregel moet een geldig onderwerp ID hebben.", nameof(onderwerpId));
        }
        if (string.IsNullOrWhiteSpace(onderwerpNaam))
        {
            throw new ArgumentException("Een auditregel moet een onderwerpnaam hebben.", nameof(onderwerpNaam));
        }
        if (doorId == Guid.Empty)
        {
            throw new ArgumentException("Een auditregel moet een geldig ID hebben door wie de wijziging is doorgevoerd.", nameof(doorId));
        }
        if (string.IsNullOrWhiteSpace(doorNaam))
        {
            throw new ArgumentException("Een auditregel moet een naam hebben door wie de wijziging is doorgevoerd.", nameof(doorNaam));
        }
        if (string.IsNullOrWhiteSpace(na))
        {
            throw new ArgumentException("Een auditregel moet een toestand na de wijziging hebben.", nameof(na));
        }
        if (string.IsNullOrWhiteSpace(reden))
        {
            throw new ArgumentException("Een auditregel moet een reden hebben.", nameof(reden));
        }

        Tijdstip = tijdstip;
        SoortWijziging = soortWijziging;
        OnderwerpCategorie = onderwerpCategorie;
        OnderwerpId = onderwerpId;
        OnderwerpNaam = onderwerpNaam;
        DoorNaam = doorNaam;
        DoorId = doorId;
        Voor = voor;
        Na = na;
        Reden = reden;

    }

    public long Id { get; private set;  }
    
    public DateTime Tijdstip { get; }

    public SoortWijziging SoortWijziging { get; }

    public OnderwerpSoort OnderwerpCategorie { get; }

    public Guid OnderwerpId { get; }
    
    public string OnderwerpNaam { get; }

    public Guid DoorId { get; }

    public string DoorNaam { get; }

    public string? Voor { get; }

    public string Na { get; }

    public string Reden { get; }
}