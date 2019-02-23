using Xunit;
using FluentAssertions;
using WorldCup.DomainService.Interfaces;
using WorldCup.DomainService.Services;
using WorldCup.Infra.InMemory.Repositories;
using Microsoft.EntityFrameworkCore;
using WorldCup.Infra.InMemory.Context;
using System;
using WorldCup.Domain.Interfaces.Repositories;
using WorldCup.Domain.Entities;
using System.Linq;

namespace WorldCup.XUnitTest
{
    public class RafflesServiceTest : IDisposable
    {
        private readonly IRafflesService _rafflesService;
        private readonly ITeamRepository _teamRepository;

        public RafflesServiceTest()
        {
            _rafflesService = new RafflesService(GetInMemoryTeamRepository());
            _teamRepository = GetInMemoryTeamRepository();
        }

        [Fact]
        public void TestRafflesOctavesFinal()
        {
            /* ================== Montando Cenario =================== */

            //IRafflesService rafflesService = new RafflesService(GetInMemoryTeamRepository());

            _teamRepository.Add(new Team("Brasil", "BRA"));
            _teamRepository.Add(new Team("Argentina", "ARG"));
            _teamRepository.Add(new Team("Uruguai", "URU"));
            _teamRepository.Add(new Team("Colombia", "COL"));
            _teamRepository.Add(new Team("Paraguai", "PAR"));
            _teamRepository.Add(new Team("Alemanha", "ALE"));
            _teamRepository.Add(new Team("Holanda", "HOL"));
            _teamRepository.Add(new Team("Espanha", "ESP"));
            _teamRepository.Add(new Team("Inglaterra", "ING"));
            _teamRepository.Add(new Team("Belgica", "BEL"));
            _teamRepository.Add(new Team("Croacia", "CRO"));
            _teamRepository.Add(new Team("Italia", "ITA"));
            _teamRepository.Add(new Team("Marrocos", "MAR"));
            _teamRepository.Add(new Team("Nigeria", "NIG"));
            _teamRepository.Add(new Team("Mexico", "Mex"));
            _teamRepository.Add(new Team("Costa Rica", "COS"));

            var selections = _teamRepository.GetAll().ToList();

            /* ================== Execucao =================== */
            var dict = _rafflesService.RafflesOctavesFinal(selections);

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

            _teamRepository.Add(new Team("Brasil", "BRA"));
            _teamRepository.Add(new Team("Argentina", "ARG"));
            _teamRepository.Add(new Team("Uruguai", "URU"));
            _teamRepository.Add(new Team("Colombia", "COL"));
            _teamRepository.Add(new Team("Paraguai", "PAR"));
            _teamRepository.Add(new Team("Alemanha", "ALE"));
            _teamRepository.Add(new Team("Holanda", "HOL"));
            _teamRepository.Add(new Team("Espanha", "ESP"));

            var selections = _teamRepository.GetAll().ToList();

            /* ================== Execucao =================== */
            var dict = _rafflesService.RafflesQuarterFinal(selections);

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

            _teamRepository.Add(new Team("Brasil", "BRA"));
            _teamRepository.Add(new Team("Argentina", "ARG"));
            _teamRepository.Add(new Team("Uruguai", "URU"));
            _teamRepository.Add(new Team("Colombia", "COL"));

            var selections = _teamRepository.GetAll().ToList();

            /* ================== Execucao =================== */
            var dict = _rafflesService.RafflesSemiFinal(selections);

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
