namespace Autorisatiematrix.Domain;

public sealed class Uitzondering
{
    public Uitzondering(Recht recht, string reden, string eigenaar, DateOnly vervaldatum)
    {
        if (string.IsNullOrWhiteSpace(reden))
        {
            throw new ArgumentException("Een uitzondering moet een reden hebben.", nameof(reden));
        }
        
        if (string.IsNullOrWhiteSpace(eigenaar))
        {
            throw new ArgumentException("Een uitzondering moet een eigenaar hebben.", nameof(eigenaar));
        }

        if (vervaldatum == default)
        {
            throw new ArgumentException("Een uitzondering moet een vervaldatum hebben.", nameof(vervaldatum));
        }

        Recht = recht;
        Reden = reden;
        Eigenaar = eigenaar;
        Vervaldatum = vervaldatum;
    }
    
    public Recht Recht { get; }

    public string Reden { get; }

    public string Eigenaar { get; }

    public DateOnly Vervaldatum { get; }

    public bool IsGeldigOp(DateOnly datum)
    {
        return datum < Vervaldatum;
    }
}