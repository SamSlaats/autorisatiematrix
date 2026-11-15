namespace  Autorisatiematrix.Domain;

public sealed class Medewerker
{
    private readonly HashSet<Rol> _rollen = new();
    private readonly HashSet<Uitzondering> _uitzonderingen = new();

    public Medewerker(string naam)
    {
        if (string.IsNullOrWhiteSpace(naam))
        {
            throw new ArgumentException("Een medewerker moet een naam hebben.", nameof(naam));
        }
        Naam = naam;
    }

    public string Naam { get; }

    public IReadOnlyCollection<Rol> Rollen => _rollen;

    public IReadOnlyCollection<Uitzondering> Uitzonderingen => _uitzonderingen;

    public void WijRolToe(Rol rol)
    {
        _rollen.Add(rol);
    }

    public void VoegUitzonderingToe(Uitzondering uitzondering)
    {
        _uitzonderingen.Add(uitzondering);
    }

    public IReadOnlySet<Recht> EffectieveRechtenOp(DateOnly vandaag)
    {
        return EffectieveRechten.Bereken(_rollen, _uitzonderingen, vandaag);
    }
}