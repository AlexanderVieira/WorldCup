using Microsoft.EntityFrameworkCore;
using System;
using WorldCup.Application;
using WorldCup.Domain.Entities;
using WorldCup.Domain.Interfaces.Repositories;
using WorldCup.DomainService.Services;
using WorldCup.Infra.InMemory.Context;
using WorldCup.Infra.InMemory.Repositories;
using WorldCup.Presentation.Controllers;
using Xunit;
using FluentAssertions;

namespace WorldCup.XUnitTest
{
    public class TestTeamController : IDisposable
    {        
        [Fact]
        public void IndexTest()
        {
            /* ================== Montando Cenario =================== */

            var teamController = new TeamController(
                new TeamAppService(new BaseService<Team>(GetInMemoryTeamRepository())),
                new MatchAppService(new MatchService(GetInMemoryTeamRepository())),
                new RafflesAppService(new RafflesService(GetInMemoryTeamRepository())));

            /* ================== Execucao =================== */
            var actionResult = teamController.Index();

            /* ================== Verificacao =================== */

            // Testando com Assert
            Assert.NotNull(actionResult);

            // Testando com FluentAssertions
            actionResult.Should().NotBeNull(actionResult.ToString(),
                $"O objeto esperado não corresponde com ao objeto obtido" +
                $" ({actionResult.ToString()})");

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
