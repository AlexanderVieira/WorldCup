using System.Collections.Generic;
using WorldCup.Domain.Entities;

namespace WorldCup.DomainService.Interfaces
{
    public interface IRafflesService
    {
        Dictionary<string, List<Team>> RafflesOctavesFinal(List<Team> selections);
        Dictionary<string, List<Team>> RafflesQuarterFinal(List<Team> selections);
        Dictionary<string, List<Team>> RafflesSemiFinal(List<Team> selections);
    }
}
