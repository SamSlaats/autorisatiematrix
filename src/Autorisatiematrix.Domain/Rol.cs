namespace Autorisatiematrix.Domain;

public sealed class Rol
{
    private readonly HashSet<Recht> _rechten = new();

    public Rol(string naam, IEnumerable<Recht> rechten)
    {
        Id = Guid.NewGuid();
        Naam = naam;
        _rechten = rechten.ToHashSet();
    }
    private Rol(Guid id, string naam)
    {
        Id = id;
        Naam = naam;
    }

    public Guid Id { get; }

    public string Naam { get; }

    public IReadOnlySet<Recht> Rechten => _rechten;
}