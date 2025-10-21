using Microsoft.EntityFrameworkCore;

namespace WarhammerStats.Core;

public class WarhammerContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5435;Database=warhammer;Username=postgres;Password=postgres"
        );
    }

}