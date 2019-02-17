using System.Collections.Generic;
using WorldCup.Domain.Entities;

namespace WorldCup.DomainService.Interfaces
{
    public interface IRafflesService
    {
        Dictionary<string, List<Team>> RafflesOctavesFinal();
        Dictionary<string, List<Team>> RafflesQuarterFinal();
        Dictionary<string, List<Team>> RafflesSemiFinal();
    }
}
