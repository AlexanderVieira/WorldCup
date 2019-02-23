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

        public List<Team> PlayOctavesFinal(Dictionary<string, List<Team>> dictOctavesFinal)
        {
            return _matchService.PlayOctavesFinal(dictOctavesFinal);
        }

        public List<Team> PlayQuarterFinal(Dictionary<string, List<Team>> dictQuarterFinal)
        {
            return _matchService.PlayQuarterFinal(dictQuarterFinal);
        }

        public List<Team> PlaySemiFinal(Dictionary<string, List<Team>> dictSemiFinal)
        {
            return _matchService.PlaySemiFinal(dictSemiFinal);
        }

        public Team PlayFinal(List<Team> finals)
        {
            return _matchService.PlayFinal(finals);
        }
    }
}
