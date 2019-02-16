using WorldCup.Domain.Entities;
using WorldCup.Domain.Interfaces;
using WorldCup.Infra.InMemory.Context;

namespace WorldCup.Infra.InMemory.Repositories
{
    public class TeamRepository : BaseRepository<Team>, IBaseRepository<Team>
    {
        public TeamRepository(WorldCupContext context) : base(context)
        {
        }
    }
}
