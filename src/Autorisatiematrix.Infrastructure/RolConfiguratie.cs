using Autorisatiematrix.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorisatiematrix.Infrastructure;

internal sealed class RolConfiguratie : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Rollen");
        builder.HasKey(rol => rol.Id);
        builder.Property(rol => rol.Naam).IsRequired().HasMaxLength(100);

        builder.OwnsMany(rol => rol.Rechten, recht =>
        {
            recht.ToTable("RolRechten");
            recht.WithOwner().HasForeignKey("RolId");
            recht.Property(r => r.Naam).HasColumnName("Recht").HasMaxLength(256);
            recht.HasKey("RolId", "Naam");
        });
    }
}