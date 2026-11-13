namespace Autorisatiematrix.Domain;

public static class EffectieveRechten
{
    public static IReadOnlySet<Recht> Bereken(
        IEnumerable<Rol> rollen,
        IEnumerable<Uitzondering> uitzonderingen,
        DateOnly vandaag)
    {
        return new HashSet<Recht>();
    }
}