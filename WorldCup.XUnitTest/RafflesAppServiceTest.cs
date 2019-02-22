using Microsoft.EntityFrameworkCore;
using System;
using WorldCup.Application;
using WorldCup.Application.Interfaces;
using WorldCup.Domain.Interfaces.Repositories;
using WorldCup.DomainService.Services;
using WorldCup.Infra.InMemory.Context;
using WorldCup.Infra.InMemory.Repositories;
using Xunit;
using FluentAssertions;

namespace WorldCup.XUnitTest
{
    public class RafflesAppServiceTest : IDisposable
    {
        [Fact]
        public void TestRafflesAppServiceOctavesFinal()
        {
            /* ================== Montando Cenario =================== */

            IRafflesAppService rafflesAppService = new RafflesAppService(new RafflesService(GetInMemoryTeamRepository()));

            /* ================== Execucao =================== */
            var dict = rafflesAppService.RafflesOctavesFinal();

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.True(dict.ContainsKey("Key:1"));
            Assert.Equal(8, dict.Count);

            // Testando com FluentAssertions
            //dict.Should().ContainKey("Key:1",
            //    $"O objeto esperado não corresponde com ao objeto obtido" +
            //    $" ({dict.ContainsKey("Key:1").ToString()})");

        }

        [Fact]
        public void TestRafflesAppServiceQuarterFinal()
        {
            /* ================== Montando Cenario =================== */

            IRafflesAppService rafflesAppService = new RafflesAppService(new RafflesService(GetInMemoryTeamRepository()));

            /* ================== Execucao =================== */
            var dict = rafflesAppService.RafflesQuarterFinal();

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.True(dict.ContainsKey("Key:1"));
            Assert.Equal(4, dict.Count);

            // Testando com FluentAssertions
            //dict.Should().ContainKey("Key:1",
            //    $"O objeto esperado não corresponde com ao objeto obtido" +
            //    $" ({dict.ContainsKey("Key:1").ToString()})");

        }

        [Fact]
        public void TestRafflesAppServiceSemiFinal()
        {
            /* ================== Montando Cenario =================== */

            IRafflesAppService rafflesAppService = new RafflesAppService(new RafflesService(GetInMemoryTeamRepository()));

            /* ================== Execucao =================== */
            var dict = rafflesAppService.RafflesSemiFinal();

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.True(dict.ContainsKey("Key:1"));
            Assert.Equal(2, dict.Count);

            // Testando com FluentAssertions
            //dict.Should().ContainKey("Key:1",
            //    $"O objeto esperado não corresponde com ao objeto obtido" +
            //    $" ({dict.ContainsKey("Key:1").ToString()})");

        }

        private ITeamRepository GetInMemoryTeamRepository()
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
