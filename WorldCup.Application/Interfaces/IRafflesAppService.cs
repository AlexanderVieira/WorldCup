using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.Domain.Entities;

namespace WorldCup.Application.Interfaces
{
    public interface IRafflesAppService
    {
        Dictionary<string, List<Team>> RafflesOctavesFinal(List<Team> selections);
        Dictionary<string, List<Team>> RafflesQuarterFinal(List<Team> selections);
        Dictionary<string, List<Team>> RafflesSemiFinal(List<Team> selections);
    }
}
