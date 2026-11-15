namespace Autorisatiematrix.Domain;

public static class EffectieveRechten
{
    public static IReadOnlySet<Recht> Bereken(
        IEnumerable<Rol> rollen,
        IEnumerable<Uitzondering> uitzonderingen,
        DateOnly vandaag)
    {
        var rechten = new HashSet<Recht>();

        foreach (var rol in rollen)
        {
            foreach (var recht in rol.Rechten)
            {
                rechten.Add(recht);
            }
        }

        foreach (var uitzondering in uitzonderingen)
        {
            rechten.Add(uitzondering.Recht);
        }
        return rechten;
    }
}