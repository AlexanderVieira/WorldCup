using WorldCup.Domain.Entities;
using WorldCup.Domain.Interfaces;
using WorldCup.Domain.Interfaces.Repositories;
using WorldCup.Infra.InMemory.Context;

namespace WorldCup.Infra.InMemory.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(WorldCupContext context) : base(context)
        {
        }
    }
}
