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
        private List<Team> _disqualifiedSelectionsOctavesFinal;
        private List<Team> _disqualifiedSelectionsQuarterFinal;
        private List<Team> _disqualifiedSelectionsSemiFinal;
        private List<Team> _classifiedSelections;
        
        public MatchService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
            _disqualifiedSelectionsOctavesFinal = new List<Team>();
            _disqualifiedSelectionsQuarterFinal = new List<Team>();
            _disqualifiedSelectionsSemiFinal = new List<Team>();
        }

        public Dictionary<string, List<Team>> PlayOctavesFinal(Dictionary<string, List<Team>> dictOctavesFinal)
        {
            var rnd = new Random();            
            
            for (int i = 0; i < 8; i++)
            {
                while (true)
                {
                    if (i == 8)
                    {
                        break;
                    }
                    var teamA = new Team
                    {
                        Name = dictOctavesFinal["Key:" + (i + 1).ToString()][0].ToString(),
                        Scoreboard = rnd.Next(0, 6)
                    };

                    var teamB = new Team
                    {
                        Name = dictOctavesFinal["Key:" + (i + 1).ToString()][1].ToString(),
                        Scoreboard = rnd.Next(0, 6)
                    };

                    if (teamA.Scoreboard > teamB.Scoreboard)
                    {
                        dictOctavesFinal["Key:" + (i + 1).ToString()].RemoveAt(1);
                        _teamRepository.Add(teamA);
                        _disqualifiedSelectionsOctavesFinal.Add(teamB);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dictOctavesFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        _teamRepository.Add(teamB);
                        _disqualifiedSelectionsOctavesFinal.Add(teamA);
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            _classifiedSelections = _teamRepository.GetAll().ToList();
            var dictResultOctavesFinal = new Dictionary<string, List<Team>> {

                { "Winner", _classifiedSelections },
                { "Disqualified", _disqualifiedSelectionsOctavesFinal}
            };
            return dictResultOctavesFinal;
        }

        public Dictionary<string, List<Team>> PlayQuarterFinal(Dictionary<string, List<Team>> dictQuarterFinal)
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
                    var teamA = new Team
                    {
                        Name = dictQuarterFinal["Key:" + (i + 1).ToString()][0].ToString(),
                        Scoreboard = rnd.Next(0, 6)
                    };

                    var teamB = new Team
                    {
                        Name = dictQuarterFinal["Key:" + (i + 1).ToString()][1].ToString(),
                        Scoreboard = rnd.Next(0, 6)
                    };

                    if (teamA.Scoreboard > teamB.Scoreboard)
                    {
                        dictQuarterFinal["Key:" + (i + 1).ToString()].RemoveAt(1);
                        _teamRepository.Add(teamA);
                        _disqualifiedSelectionsQuarterFinal.Add(teamB);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dictQuarterFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        _teamRepository.Add(teamB);
                        _disqualifiedSelectionsQuarterFinal.Add(teamA);
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            
            _classifiedSelections = _teamRepository.GetAll().ToList();
            var dictResultQuarterFinal = new Dictionary<string, List<Team>> {

                { "Winner", _classifiedSelections },
                { "Disqualified", _disqualifiedSelectionsQuarterFinal}
            };
            return dictResultQuarterFinal;
        }

        public Dictionary<string, List<Team>> PlaySemiFinal(Dictionary<string, List<Team>> dictSemiFinal)
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
                    var teamA = new Team
                    {
                        Name = dictSemiFinal["Key:" + (i + 1).ToString()][0].ToString(),
                        Scoreboard = rnd.Next(0, 6)
                    };

                    var teamB = new Team
                    {
                        Name = dictSemiFinal["Key:" + (i + 1).ToString()][1].ToString(),
                        Scoreboard = rnd.Next(0, 6)
                    };

                    if (teamA.Scoreboard > teamB.Scoreboard)
                    {
                        dictSemiFinal["Key:" + (i + 1).ToString()].RemoveAt(1);
                        _teamRepository.Add(teamA);
                        _disqualifiedSelectionsSemiFinal.Add(teamB);
                        i++;
                    }
                    else if (teamA.Scoreboard < teamB.Scoreboard)
                    {
                        dictSemiFinal["Key:" + (i + 1).ToString()].RemoveAt(0);
                        _teamRepository.Add(teamB);
                        _disqualifiedSelectionsSemiFinal.Add(teamA);
                        i++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            _classifiedSelections = _teamRepository.GetAll().ToList();
            var dictResultSemiFinal = new Dictionary<string, List<Team>> {

                { "Winner", _classifiedSelections },
                { "Disqualified", _disqualifiedSelectionsSemiFinal}
            };
            return dictResultSemiFinal;
        }

        public Team PlayFinal(List<Team> finals)
        {
            //var _selections = ;
            var rnd = new Random();

            while (true)
            {
                var teamA = new Team
                {
                    Name = finals[0].Name,
                    Scoreboard = rnd.Next(0, 6)
                };

                var teamB = new Team
                {
                    Name = finals[1].Name,
                    Scoreboard = rnd.Next(0, 6)
                };

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
