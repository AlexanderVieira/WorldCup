using Xunit;
using FluentAssertions;
using WorldCup.DomainService.Interfaces;
using WorldCup.DomainService.Services;
using WorldCup.Infra.InMemory.Repositories;
using Microsoft.EntityFrameworkCore;
using WorldCup.Infra.InMemory.Context;

namespace WorldCup.XUnitTest
{
    public class RafflesServiceTest
    {
        [Fact]
        public void TestAddTeams()
        {
            /* ================== Montando Cenario =================== */

            IRafflesService rafflesService = new RafflesService(new TeamService(GetInMemoryTeamRepository()));

            /* ================== Execucao =================== */
            var dict = rafflesService.RafflesOctavesFinal();

            /* ================== Verificacao =================== */

            // Testando com Assert
            //Assert.True(dict.ContainsKey("Chave:1"));            

            // Testando com FluentAssertions
            dict.Should().ContainKey("Chave:1",
                $"O objeto esperado não corresponde com ao objeto obtido" +
                $" ({dict.ContainsKey("Chave:1").ToString()})");
        }

        private TeamRepository GetInMemoryTeamRepository()
        {
            DbContextOptions<WorldCupContext> options;
            var builder = new DbContextOptionsBuilder<WorldCupContext>();
            options = builder.UseInMemoryDatabase(databaseName: "ConnectionTest").Options;
            var worldCupContext = new WorldCupContext(options);
            worldCupContext.Database.EnsureDeleted();
            worldCupContext.Database.EnsureCreated();
            return new TeamRepository(worldCupContext);
        }
    }
}
