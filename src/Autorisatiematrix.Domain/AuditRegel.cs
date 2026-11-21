namespace Autorisatiematrix.Domain;

public sealed class AuditRegel
{
    public AuditRegel(DateTime tijdstip, SoortWijziging soortWijziging, OnderwerpSoort onderwerpCategorie, Guid onderwerpId, string onderwerpNaam, Guid doorId, string doorNaam, string? voor, string na, string reden)
    {
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