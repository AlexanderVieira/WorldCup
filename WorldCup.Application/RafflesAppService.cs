using System;
using System.Collections.Generic;
using WorldCup.Application.Interfaces;
using WorldCup.Domain.Entities;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.Application
{
    public class RafflesAppService : IRafflesAppService
    {
        private readonly IRafflesService _rafflesService;

        public RafflesAppService(IRafflesService rafflesService)
        {
            _rafflesService = rafflesService;
        }

        public Dictionary<string, List<Team>> RafflesOctavesFinal(List<Team> selections)
        {
            return _rafflesService.RafflesOctavesFinal(selections);
        }

        public Dictionary<string, List<Team>> RafflesQuarterFinal(List<Team> selections)
        {
            return _rafflesService.RafflesQuarterFinal(selections);
        }

        public Dictionary<string, List<Team>> RafflesSemiFinal(List<Team> selections)
        {
            return _rafflesService.RafflesSemiFinal(selections);
        }
    }
}
