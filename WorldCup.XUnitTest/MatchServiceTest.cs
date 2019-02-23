using Microsoft.EntityFrameworkCore;
using System;
using WorldCup.DomainService.Interfaces;
using WorldCup.DomainService.Services;
using WorldCup.Infra.InMemory.Context;
using WorldCup.Infra.InMemory.Repositories;
using Xunit;
using FluentAssertions;
using WorldCup.Domain.Interfaces.Repositories;
using System.Linq;
using WorldCup.Domain.Entities;
using System.Collections.Generic;

namespace WorldCup.XUnitTest
{
    public class MatchServiceTest : IDisposable
    {
        private readonly IMatchService _matchService;
        private readonly IRafflesService _rafflesService;
        private readonly ITeamRepository _teamRepository;
        private List<Team> finals;

        public MatchServiceTest()
        {
            _matchService = new MatchService(GetInMemoryTeamRepository());
            _rafflesService = new RafflesService(GetInMemoryTeamRepository());
            _teamRepository = GetInMemoryTeamRepository();
            finals = new List<Team>();
        }

        [Fact]
        public void TestListTeamsOctavesFinal()
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
            var list = _matchService.PlayOctavesFinal(_rafflesService.RafflesOctavesFinal(selections));

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
            var list = _matchService.PlayQuarterFinal(_rafflesService.RafflesQuarterFinal(selections));

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

            _teamRepository.Add(new Team("Brasil", "BRA"));
            _teamRepository.Add(new Team("Argentina", "ARG"));
            _teamRepository.Add(new Team("Uruguai", "URU"));
            _teamRepository.Add(new Team("Colombia", "COL"));

            var selections = _teamRepository.GetAll().ToList();

            /* ================== Execucao =================== */
            var finals = _matchService.PlaySemiFinal(_rafflesService.RafflesSemiFinal(selections));

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.NotEmpty(finals);
            Assert.Equal(2, finals.Count);

            // Testando com FluentAssertions
            //dict.Should().ContainKey("Key:1",
            //    $"O objeto esperado não corresponde com ao objeto obtido" +
            //    $" ({dict.ContainsKey("Key:1").ToString()})");

        }

        [Fact]
        public void TestPlayFinal()
        {
            /* ================== Montando Cenario =================== */

            _teamRepository.Add(new Team("Brasil", "BRA"));
            _teamRepository.Add(new Team("Argentina", "ARG"));

            var selections = _teamRepository.GetAll().ToList();

            /* ================== Execucao =================== */
            var championTeam = _matchService.PlayFinal(selections);

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.NotNull(championTeam.Name);

            // Testando com FluentAssertions
            //championTeam.Should().NotBeNull(championTeam.Name,
            //    $"O objeto esperado não corresponde com ao objeto obtido" +
            //    $" ({championTeam.Name})");

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
