using System.Collections.Generic;
using WorldCup.Domain.Entities;

namespace WorldCup.Application.Interfaces
{
    public interface IMatchAppService
    {
        List<Team> PlayOctavesFinal(Dictionary<string, List<Team>> dictOctavesFinal);
        List<Team> PlayQuarterFinal(Dictionary<string, List<Team>> dictQuarterFinal);
        List<Team> PlaySemiFinal(Dictionary<string, List<Team>> dictSemiFinal);
        Team PlayFinal(List<Team> finals);
    }
}
