namespace Autorisatiematrix.Domain;

public sealed class Rol
{
    public Rol(string naam, IEnumerable<Recht> rechten)
    {
        Naam = naam;
        Rechten = rechten.ToHashSet();
    }

    public string Naam { get; }

    public IReadOnlySet<Recht> Rechten { get; }
}