using Microsoft.EntityFrameworkCore;
using System;
using WorldCup.DomainService.Interfaces;
using WorldCup.DomainService.Services;
using WorldCup.Infra.InMemory.Context;
using WorldCup.Infra.InMemory.Repositories;
using Xunit;
using FluentAssertions;

namespace WorldCup.XUnitTest
{
    public class MatchServiceTest : IDisposable
    {
        [Fact]
        public void TestListTeamsOctavesFinal()
        {
            /* ================== Montando Cenario =================== */
            
            IMatchService matchService = new MatchService(new RafflesService(GetInMemoryTeamRepository()));

            /* ================== Execucao =================== */
            var list = matchService.PlayOctavesFinal();

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.NotEmpty(list);
            Assert.Equal(8, list.Count);

            // Testando com FluentAssertions
            //dict.Should().ContainKey("Key:1",
            //    $"O objeto esperado não corresponde com ao objeto obtido" +
            //    $" ({dict.ContainsKey("Key:1").ToString()})");

        }

        [Fact]
        public void TestListTeamsQuarterFinal()
        {
            /* ================== Montando Cenario =================== */

            IMatchService matchService = new MatchService(new RafflesService(GetInMemoryTeamRepository()));

            /* ================== Execucao =================== */
            var list = matchService.PlayQuarterFinal();

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.NotEmpty(list);
            Assert.Equal(4, list.Count);

            // Testando com FluentAssertions
            //dict.Should().ContainKey("Key:1",
            //    $"O objeto esperado não corresponde com ao objeto obtido" +
            //    $" ({dict.ContainsKey("Key:1").ToString()})");

        }

        [Fact]
        public void TestListTeamsSemiFinal()
        {
            /* ================== Montando Cenario =================== */

            IMatchService matchService = new MatchService(new RafflesService(GetInMemoryTeamRepository()));

            /* ================== Execucao =================== */
            var list = matchService.PlaySemiFinal();

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.NotEmpty(list);
            Assert.Equal(2, list.Count);

            // Testando com FluentAssertions
            //dict.Should().ContainKey("Key:1",
            //    $"O objeto esperado não corresponde com ao objeto obtido" +
            //    $" ({dict.ContainsKey("Key:1").ToString()})");

        }

        private TeamRepository GetInMemoryTeamRepository()
        {
            DbContextOptions<WorldCupContext> options;
            var builder = new DbContextOptionsBuilder<WorldCupContext>();
            options = builder.UseInMemoryDatabase(databaseName: "WorldCupDB").Options;
            var worldCupContext = new WorldCupContext(options);
            worldCupContext.Database.EnsureDeleted();
            worldCupContext.Database.EnsureCreated();
            return new TeamRepository(worldCupContext);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(GetInMemoryTeamRepository());
        }
    }
}
