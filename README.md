# Autorisatiematrix

Leerproject in C#/.NET: een app die een autorisatiematrix (rol × groep) overzichtelijk toont, laat bewerken en de wijzigingen doorvoert naar Microsoft Entra ID en on-prem Active Directory.

- **Ontwerpbeslissingen:** [docs/ontwerp.md](docs/ontwerp.md)
- **Leerroute:** de issues, gegroepeerd per mijlpaal. Werk ze in volgorde af; elk issue noemt waar het van afhankelijk is.

| Mijlpaal | Inhoud |
|---|---|
| M0 Fundament | Solution, CI, testtenant, inloggen |
| M1 Domein en opslag | Rechtenmodel (TDD), EF Core, auditlog |
| M2 Entra lezen | `IDirectoryTarget`, Graph uitlezen |
| M3 Matrix-UI | Rollen, toewijzingen, effectieve rechten |
| M4 Vergelijken | Gewenst versus werkelijk, verschillenoverzicht |
| M5 Doorvoeren naar Entra | Per actie doorvoeren en loggen |
| M6 Uitzonderingen en afwijkingen | Uitzonderingen, afwijkingen afhandelen |
| M7 Hybride met AD | Lab, LDAP, bron van gezag |
| v2 | Periodieke vergelijking en meer |

> Testen gebeurt uitsluitend in een eigen testtenant en het lab.
