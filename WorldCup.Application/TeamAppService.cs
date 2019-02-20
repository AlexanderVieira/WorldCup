using WorldCup.Application.Interfaces;
using WorldCup.Domain.Entities;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.Application
{
    public class TeamAppService : BaseAppService<Team>, ITeamAppService
    {
        public TeamAppService(IBaseService<Team> baseService) : base(baseService)
        {
        }
    }
}
