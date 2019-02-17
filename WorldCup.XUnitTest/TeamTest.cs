using Xunit;
using FluentAssertions;
using WorldCup.Domain.Entities;
using System;

namespace WorldCup.XUnitTest
{
    /// <summary>
    /// Classe criada para garantir o funcionamento
    /// das operações realizadas pela classe
    /// @Autor: Alexander Silva
    /// </summary>
    public class TeamTest : IDisposable
    {
        private Team brasil;

        [Fact]
        public void TestCreatingNewTeam()
        {
            /* ================== Montando Cenario =================== */
            brasil = new Team { TeamId = 1, Name = "Brasil", Flag = "BRA" };

            /* ================== Execucao =================== */
            var teamName = brasil.Name;
            var expectedTeamName = "Brasil";

            /* ================== Verificacao =================== */

            // Testando com Assert
            //Assert.Equal(expectedTeamName, teamName);

            // Testando com FluentAssertions
            teamName.Should().Be(expectedTeamName, 
                $"O nome do time esperado não corresponde com o objeto obtido ({teamName})");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(brasil);
        }
    }
}
