namespace Autorisatiematrix.Domain;

// Namen nooit wijzigen: ze worden als tekst in het auditlog opgeslagen.
// Een hernoemde waarde maakt de oude regels onleesbaar, zonder foutmelding en niet te repareren.
public enum OnderwerpSoort
{
    Rol,
    Medewerker
}