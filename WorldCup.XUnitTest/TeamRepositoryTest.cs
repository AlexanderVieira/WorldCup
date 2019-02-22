using Microsoft.EntityFrameworkCore;
using WorldCup.Infra.InMemory.Context;
using WorldCup.Infra.InMemory.Repositories;
using Xunit;
using WorldCup.Domain.Entities;
using System.Linq;
using FluentAssertions;
using WorldCup.Domain.Interfaces.Repositories;
using System;

namespace WorldCup.XUnitTest
{
    /// <summary>
    /// Classe de teste que garante o funcionamento
    /// das operações realizadas pela classe TeamRepository.
    /// @Autor: Alexander Silva
    /// </summary>
    public class TeamRepositoryTest : IDisposable
    {
        [Fact]
        public void TestAddTeam()
        {
            /* ================== Montando Cenario =================== */
            ITeamRepository teamRepository = GetInMemoryTeamRepository();
            var brasil = new Team("Brasil", "BRA");

            /* ================== Execucao =================== */
            var teamSaved = teamRepository.Add(brasil);

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.NotEmpty(teamRepository.GetAll().ToList());
            //Assert.Equal(1, teamSaved.TeamId);
            Assert.Equal("Brasil", teamSaved.Name);
            Assert.Equal("BRA", teamSaved.Flag);

            // Testando com FluentAssertions
            //teamRepository.Should().NotBeNull(teamRepository.GetAll().ToList().Count.ToString(), 
            //    $"O objeto esperado não corresponde com ao objeto obtido" +
            //    $" ({teamRepository.GetAll().ToList().Count.ToString()})");

            //teamSaved.TeamId.Should().Be(1, 
            //    $"O Id do objeto esperado não corresponde com o Id do objeto obtido {teamSaved.TeamId}");
            //teamSaved.Name.Should().Be("Brasil", 
            //    $"O nome do time esperado não corresponde com o nome obtido {teamSaved.Name}");
            //teamSaved.Flag.Should().Be("BRA", 
            //    $"A bandeira não corresponde coma a obtida {teamSaved.Flag}");            
            
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
