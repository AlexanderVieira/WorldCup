using Microsoft.EntityFrameworkCore;
using WorldCup.Domain.Entities;
using WorldCup.DomainService.Interfaces;
using WorldCup.DomainService.Services;
using WorldCup.Infra.InMemory.Context;
using WorldCup.Infra.InMemory.Repositories;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace WorldCup.XUnitTest
{
    /// <summary>
    /// Classe de teste que garante o funcionamento
    /// das operações realizadas pela classe TeamService.
    /// @Autor: Alexander Silva
    /// </summary>
    public class TeamServiceTest
    {
        [Fact]
        public void TestAddTeam()
        {
            /* ================== Montando Cenario =================== */
            
            ITeamService teamService = new TeamService(GetInMemoryTeamRepository()) ;
            var brasil = new Team(1, "Brasil", "BRA");

            /* ================== Execucao =================== */
            var teamSaved = teamService.Add(brasil);

            /* ================== Verificacao =================== */

            // Testando com Assert
            //Assert.Single(teamService.GetAll().ToList());
            //Assert.Equal(1, teamSaved.TeamId);
            //Assert.Equal("Brasil", teamSaved.Name);
            //Assert.Equal("BRA", teamSaved.Flag);

            // Testando com FluentAssertions
            teamService.Should().NotBeNull(teamService.GetAll().ToList().Count.ToString(),
                $"O objeto esperado não corresponde com ao objeto obtido" +
                $" ({teamService.GetAll().ToList().Count.ToString()})");

            teamSaved.TeamId.Should().Be(1,
                $"O Id do objeto esperado não corresponde com o Id do objeto obtido {teamSaved.TeamId}");
            teamSaved.Name.Should().Be("Brasil",
                $"O nome do time esperado não corresponde com o nome obtido {teamSaved.Name}");
            teamSaved.Flag.Should().Be("BRA",
                $"A bandeira não corresponde coma a obtida {teamSaved.Flag}");
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
