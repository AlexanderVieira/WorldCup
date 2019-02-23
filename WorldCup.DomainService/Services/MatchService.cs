using System;
using System.Collections.Generic;
using System.Linq;
using WorldCup.Domain.Entities;
using WorldCup.Domain.Interfaces.Repositories;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.DomainService.Services
{    
    public class MatchService : IMatchService        
    {
        private readonly ITeamRepository _teamRepository;
        private List<Team> _selections;        
        
        public MatchService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;                     
        }        

        public List<Team> PlayOctavesFinal(Dictionary<string, List<Team>> dictOctavesFinal)
        {
            //var _selections = new List<Team>();
            //var dictOctavesFinal = keyValues;
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
                        _teamRepository.Add(teamA);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dictOctavesFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        _teamRepository.Add(teamB);
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return _selections = _teamRepository.GetAll().ToList();
        }

        public List<Team> PlayQuarterFinal(Dictionary<string, List<Team>> dictQuarterFinal)
        {            
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
                    teamA.Name = dictQuarterFinal["Key:" + (i + 1).ToString()][0].ToString();
                    teamA.Scoreboard = rnd.Next(0, 6);

                    teamB.Name = dictQuarterFinal["Key:" + (i + 1).ToString()][1].ToString();
                    teamB.Scoreboard = rnd.Next(0, 6);

                    if (teamA.Scoreboard > teamB.Scoreboard)
                    {
                        dictQuarterFinal["Key:" + (i + 1).ToString()].RemoveAt(1);
                        _teamRepository.Add(teamA);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dictQuarterFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        _teamRepository.Add(teamB);
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return _selections = _teamRepository.GetAll().ToList();
        }

        public List<Team> PlaySemiFinal(Dictionary<string, List<Team>> dictSemiFinal)
        {            
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
                    teamA.Name = dictSemiFinal["Key:" + (i + 1).ToString()][0].ToString();
                    teamA.Scoreboard = rnd.Next(0, 6);

                    teamB.Name = dictSemiFinal["Key:" + (i + 1).ToString()][1].ToString();
                    teamB.Scoreboard = rnd.Next(0, 6);

                    if (teamA.Scoreboard > teamB.Scoreboard)
                    {
                        dictSemiFinal["Key:" + (i + 1).ToString()].RemoveAt(1);
                        _teamRepository.Add(teamA);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dictSemiFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        _teamRepository.Add(teamB);
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return _selections = _teamRepository.GetAll().ToList();
        }

        public Team PlayFinal(List<Team> finals)
        {
            //var _selections = ;
            var rnd = new Random();

            while (true)
            {
                var teamA = new Team();
                var teamB = new Team();
                teamA.Name = finals[0].Name;
                teamA.Scoreboard = rnd.Next(0, 6);

                teamB.Name = finals[1].Name;
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
    }
}
