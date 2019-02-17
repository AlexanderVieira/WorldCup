using System;
using System.Collections.Generic;
using System.Linq;
using WorldCup.Domain.Entities;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.DomainService.Services
{
    public class MatchService : IMatchService
    {
        private readonly IRafflesService _rafflesService;

        public MatchService(IRafflesService rafflesService)
        {
            _rafflesService = rafflesService;
        }

        public List<Team> PlayOctavesFinal()
        {
            var selections = new List<Team>();
            var dictOctavesFinal = _rafflesService.RafflesOctavesFinal();
            var rnd = new Random();

            
            for (int i = 0; i < 8; i++)            
            {
                while (true)
                {
                    if (i == 8)
                    {
                        break;
                    }
                    var teamA = new Team();
                    var teamB = new Team();
                    teamA.Name = dictOctavesFinal["Key:" + (i + 1).ToString()][0].ToString();
                    teamA.Scoreboard = rnd.Next(0, 6);

                    teamB.Name = dictOctavesFinal["Key:" + (i + 1).ToString()][1].ToString();
                    teamB.Scoreboard = rnd.Next(0, 6);

                    if (teamA.Scoreboard > teamB.Scoreboard)
                    {
                        dictOctavesFinal["Key:" + (i + 1).ToString()].RemoveAt(1);
                        selections.Add(teamA);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dictOctavesFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        selections.Add(teamB);
                        i++;
                    }
                    else
                    {
                        continue;
                    }

                }
            }            
            return selections;
        }
    }
}
