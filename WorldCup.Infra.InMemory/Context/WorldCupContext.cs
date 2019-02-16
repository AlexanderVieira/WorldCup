using Microsoft.EntityFrameworkCore;
using WorldCup.Domain.Entities;

namespace WorldCup.Infra.InMemory.Context
{
    public class WorldCupContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public WorldCupContext(DbContextOptions<WorldCupContext> options)
        : base(options)
        {

        }
    }
}
