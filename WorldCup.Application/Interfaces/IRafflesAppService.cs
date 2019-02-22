using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.Domain.Entities;

namespace WorldCup.Application.Interfaces
{
    public interface IRafflesAppService
    {
        Dictionary<string, List<Team>> RafflesOctavesFinal();
        Dictionary<string, List<Team>> RafflesQuarterFinal();
        Dictionary<string, List<Team>> RafflesSemiFinal();
    }
}
