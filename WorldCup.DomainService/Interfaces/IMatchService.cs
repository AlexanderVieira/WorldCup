using System.Collections.Generic;
using WorldCup.Domain.Entities;

namespace WorldCup.DomainService.Interfaces
{
    public interface IMatchService
    {
        Dictionary<string, List<Team>> PlayOctavesFinal(Dictionary<string, List<Team>> dictOctavesFinal);
        Dictionary<string, List<Team>> PlayQuarterFinal(Dictionary<string, List<Team>> dictQuarterFinal);
        Dictionary<string, List<Team>> PlaySemiFinal(Dictionary<string, List<Team>> dictSemiFinal);
        Team PlayFinal(List<Team> finals);
    }
}
