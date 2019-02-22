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

        public Dictionary<string, List<Team>> RafflesOctavesFinal()
        {
            return _rafflesService.RafflesOctavesFinal();
        }

        public Dictionary<string, List<Team>> RafflesQuarterFinal()
        {
            return _rafflesService.RafflesQuarterFinal();
        }

        public Dictionary<string, List<Team>> RafflesSemiFinal()
        {
            return _rafflesService.RafflesSemiFinal();
        }
    }
}
