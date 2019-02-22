using System;
using System.Collections.Generic;
using WorldCup.Domain.Entities;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.DomainService.Services
{    
    public class MatchService : IMatchService        
    {
        private readonly IRafflesService _rafflesService;
        private List<Team> _selections;

        public MatchService()
        {
            _selections = new List<Team>();
        }

        public MatchService(IRafflesService rafflesService)
        {
            _rafflesService = rafflesService;
            _selections = new List<Team>();
        }

        public Team PlayFinal()
        {            
            var _selections = PlaySemiFinal();
            var rnd = new Random();
            
            while (true)
            {
                var teamA = new Team();
                var teamB = new Team();
                teamA.Name = _selections[0].Name;
                teamA.Scoreboard = rnd.Next(0, 6);

                teamB.Name = _selections[1].Name;
                teamB.Scoreboard = rnd.Next(0, 6);

                if (teamA.Scoreboard > teamB.Scoreboard)
                {                    
                    return teamA;                    
                }
                else if (teamA.Scoreboard < teamB.Scoreboard)
                {
                    return teamB;                   
                }
                else
                {
                    continue;
                }
            }

        }

        public List<Team> PlayOctavesFinal()
        {
            //var _selections = new List<Team>();
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
                        _selections.Add(teamA);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dictOctavesFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        _selections.Add(teamB);
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return _selections;
        }

        public List<Team> PlayQuarterFinal()
        {
            //var _selections = new List<Team>();
            var dicQuarterFinal = _rafflesService.RafflesQuarterFinal();
            var rnd = new Random();


            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    if (i == 4)
                    {
                        break;
                    }
                    var teamA = new Team();
                    var teamB = new Team();
                    teamA.Name = dicQuarterFinal["Key:" + (i + 1).ToString()][0].ToString();
                    teamA.Scoreboard = rnd.Next(0, 6);

                    teamB.Name = dicQuarterFinal["Key:" + (i + 1).ToString()][1].ToString();
                    teamB.Scoreboard = rnd.Next(0, 6);

                    if (teamA.Scoreboard > teamB.Scoreboard)
                    {
                        dicQuarterFinal["Key:" + (i + 1).ToString()].RemoveAt(1);
                        _selections.Add(teamA);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dicQuarterFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        _selections.Add(teamB);
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return _selections;
        }

        public List<Team> PlaySemiFinal()
        {
            //var _selections = new List<Team>();
            var dicSemiFinal = _rafflesService.RafflesSemiFinal();
            var rnd = new Random();


            for (int i = 0; i < 2; i++)
            {
                while (true)
                {
                    if (i == 2)
                    {
                        break;
                    }
                    var teamA = new Team();
                    var teamB = new Team();
                    teamA.Name = dicSemiFinal["Key:" + (i + 1).ToString()][0].ToString();
                    teamA.Scoreboard = rnd.Next(0, 6);

                    teamB.Name = dicSemiFinal["Key:" + (i + 1).ToString()][1].ToString();
                    teamB.Scoreboard = rnd.Next(0, 6);

                    if (teamA.Scoreboard > teamB.Scoreboard)
                    {
                        dicSemiFinal["Key:" + (i + 1).ToString()].RemoveAt(1);
                        _selections.Add(teamA);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dicSemiFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        _selections.Add(teamB);
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return _selections;
        }
    }
}
