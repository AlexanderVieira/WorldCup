using System;
using System.Collections.Generic;
using System.Text;
using WorldCup.Application.Interfaces;
using WorldCup.Domain.Entities;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.Application
{
    public class MatchAppService : IMatchAppService
    {
        private readonly IMatchService _matchService;

        public MatchAppService(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public Team PlayFinal()
        {
            return _matchService.PlayFinal();
        }

        public List<Team> PlayOctavesFinal()
        {
            return _matchService.PlayOctavesFinal();
        }

        public List<Team> PlayQuarterFinal()
        {
            return _matchService.PlayQuarterFinal();
        }

        public List<Team> PlaySemiFinal()
        {
            return _matchService.PlaySemiFinal();
        }
    }
}
