using System;
using Xunit;
using FluentAssertions;
using WorldCup.Domain.Entities;

namespace WorldCup.XUnitTest
{
    public class TeamTest
    {
        /// <summary>
        /// Classe criada para garantir o funcionamento
        /// das opera��es realizadas pela classe
        /// @Autor: Alexander Silva
        /// </summary>
        [Fact]
        public void TestCreatingNewTeam()
        {
            /* ================== Montando Cenario =================== */
            var brasil = new Team { TeamId = 1, Name = "Brasil", Flag = "BRA" };

            /* ================== Execucao =================== */
            var teamName = brasil.Name;
            var expectedTeamName = "Brasil";

            /* ================== Verificacao =================== */

            // Testando com Assert
            //Assert.Equal(expectedTeamName, teamName);

            // Testando com FluentAssertions
            teamName.Should().Be(expectedTeamName, 
                $"O nome do time esperado n�o corresponde com o objeto obtido ({teamName})");
        }
    }
}