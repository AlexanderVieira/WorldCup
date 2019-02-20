using Xunit;
using FluentAssertions;
using WorldCup.DomainService.Interfaces;
using WorldCup.DomainService.Services;
using WorldCup.Infra.InMemory.Repositories;
using Microsoft.EntityFrameworkCore;
using WorldCup.Infra.InMemory.Context;
using System;

namespace WorldCup.XUnitTest
{
    public class RafflesServiceTest : IDisposable
    { 
        [Fact]
        public void TestRafflesOctavesFinal()
        {
            /* ================== Montando Cenario =================== */

            IRafflesService rafflesService = new RafflesService(GetInMemoryTeamRepository());

            /* ================== Execucao =================== */
            var dict = rafflesService.RafflesOctavesFinal();

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
        public void TestRafflesQuarterFinal()
        {
            /* ================== Montando Cenario =================== */

            IRafflesService rafflesService = new RafflesService(GetInMemoryTeamRepository());

            /* ================== Execucao =================== */
            var dict = rafflesService.RafflesQuarterFinal();

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
        public void TestRafflesSemiFinal()
        {
            /* ================== Montando Cenario =================== */

            IRafflesService rafflesService = new RafflesService(GetInMemoryTeamRepository());

            /* ================== Execucao =================== */
            var dict = rafflesService.RafflesSemiFinal();

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.True(dict.ContainsKey("Key:1"));
            Assert.Equal(2, dict.Count);

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
