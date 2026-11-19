using Autorisatiematrix.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autorisatiematrix.Infrastructure;

internal sealed class UitzonderingConfiguratie : IEntityTypeConfiguration<Uitzondering>
{
    public void Configure(EntityTypeBuilder<Uitzondering> builder)
    {
        builder.ToTable("Uitzonderingen");
        builder.HasKey(uitzondering => uitzondering.Id);
        builder.Property(uitzondering => uitzondering.Reden).IsRequired().HasMaxLength(256);
        builder.Property(uitzondering => uitzondering.Eigenaar).IsRequired().HasMaxLength(100);
        builder.Property(uitzondering => uitzondering.Vervaldatum).IsRequired();

        builder.ComplexProperty(u => u.Recht, recht =>
        {
            recht.Property(r => r.Naam)
                .HasColumnName("Recht")
                .IsRequired()
                .HasMaxLength(256);
        });
    }
}