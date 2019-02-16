using WorldCup.Domain.Entities;
using WorldCup.Domain.Interfaces.Repositories;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.DomainService.Services
{
    public class TeamService : BaseService<Team>, ITeamService
    {
        public TeamService(IBaseRepository<Team> baseRepository) : base(baseRepository)
        {
        }
    }
}
