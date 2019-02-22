using System.Collections.Generic;
using WorldCup.Domain.Entities;

namespace WorldCup.Application.Interfaces
{
    public interface IMatchAppService
    {
        List<Team> PlayOctavesFinal();
        List<Team> PlayQuarterFinal();
        List<Team> PlaySemiFinal();
        Team PlayFinal();
    }
}
