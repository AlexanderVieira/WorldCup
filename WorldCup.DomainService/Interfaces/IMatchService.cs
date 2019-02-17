using System.Collections.Generic;
using WorldCup.Domain.Entities;

namespace WorldCup.DomainService.Interfaces
{
    public interface IMatchService
    {
       List<Team> PlayOctavesFinal();
    }
}
