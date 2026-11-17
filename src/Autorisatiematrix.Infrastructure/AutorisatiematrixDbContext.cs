using Autorisatiematrix.Domain;
using Microsoft.EntityFrameworkCore;

namespace Autorisatiematrix.Infrastructure;

public sealed class AutorisatiematrixDbContext : DbContext
{
    public AutorisatiematrixDbContext(DbContextOptions<AutorisatiematrixDbContext> opties)
        : base(opties)
    {
    }

    public DbSet<Rol> Rollen => Set<Rol>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutorisatiematrixDbContext).Assembly);
    }
}