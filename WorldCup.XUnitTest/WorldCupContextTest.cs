using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WorldCup.Infra.InMemory.Context;
using System.Linq;
using WorldCup.Domain.Entities;

namespace WorldCup.XUnitTest
{
    public class WorldCupContextTest
    {
        [Fact]
        public void TestWorldCupContext()
        {
            /* ================== Montando Cenario =================== */
            var options = new DbContextOptionsBuilder<WorldCupContext>()
                .UseInMemoryDatabase(databaseName: "ConnectionTest").Options;

            /* ================== Execucao =================== */
            using (var ctx = new WorldCupContext(options))
            {
                ctx.Teams.Add(new Team { TeamId = 1, Name = "Brasil", Flag = "BRA" });
                ctx.SaveChanges();

                /* ================== Verificacao =================== */

                // Testando com Assert
                //Assert.NotEmpty(ctx.Teams.ToList());

                // Testando com FluentAssertions
                ctx.Teams.ToList().Should().NotBeEmpty(ctx.Teams.ToList().ToString(),
                    $"O objeto esperado não corresponde com ao objeto obtido ({ctx.Teams.ToList().ToString()})");
            }
        }
    }
}
