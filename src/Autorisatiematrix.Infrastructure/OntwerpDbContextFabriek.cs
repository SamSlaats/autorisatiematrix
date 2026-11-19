using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Autorisatiematrix.Infrastructure;

internal sealed class OntwerpDbConextFabriek : IDesignTimeDbContextFactory<AutorisatiematrixDbContext>
{
    public AutorisatiematrixDbContext CreateDbContext(string[] args)
    {
        var opties = new DbContextOptionsBuilder<AutorisatiematrixDbContext>()
            .UseSqlite("Data Source=autorisatiematrix.db")
            .Options;

        return new AutorisatiematrixDbContext(opties);
    }
}