using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using WorldCup.Domain.Entities;

namespace WorldCup.Infra.InMemory.Context
{
    /// <summary>
    /// Classe criada que representa o contexto da aplicação
    /// @Autor: Alexander Silva
    /// </summary>
    public class WorldCupContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public WorldCupContext(DbContextOptions<WorldCupContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // obtém a configuracoes do aplicativo
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            // define a base de dados
            optionsBuilder.UseInMemoryDatabase("WorldCupDB");
        }
    }
}
