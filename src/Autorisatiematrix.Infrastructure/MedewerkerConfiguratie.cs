using Autorisatiematrix.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorisatiematrix.Infrastructure;

internal sealed class MedewerkerConfiguratie : IEntityTypeConfiguration<Medewerker>
{
    public void Configure(EntityTypeBuilder<Medewerker> builder)
    {
        builder.ToTable("Medewerkers");
        builder.HasKey(medewerker => medewerker.Id);
        builder.Property(medewerker => medewerker.Naam).IsRequired().HasMaxLength(100);

        // Veel-op-veel: een medewerker heeft meerdere rollen,
        // en een rol hoort bij meerdere medewerkers.
        builder.HasMany(medewerker => medewerker.Rollen)
            .WithMany()
            .UsingEntity(
                "MedewerkerRollen",
                koppeling => koppeling.HasOne(typeof(Rol)).WithMany().HasForeignKey("RolId"),
                koppeling => koppeling.HasOne(typeof(Medewerker)).WithMany().HasForeignKey("MedewerkerId"),
                koppeling => koppeling.HasKey("MedewerkerId", "RolId"));

        // Een-op-veel: een uitzondering hoort bij precies één medewerker.
        builder.HasMany(medewerker => medewerker.Uitzonderingen)
            .WithOne()
            .HasForeignKey("MedewerkerId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(medewerker => medewerker.Rollen).HasField("_rollen");
        builder.Navigation(medewerker => medewerker.Uitzonderingen).HasField("_uitzonderingen");
    }
}