using System;
using System.Collections.Generic;
using System.Linq;
using WorldCup.Domain.Entities;
using WorldCup.Domain.Interfaces.Repositories;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.DomainService.Services
{
    public class RafflesService : IRafflesService
    {   
        private readonly ITeamRepository _teamRepository;
        //private readonly IMatchService _matchService;
        //private List<Team> _selections;

        public RafflesService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
            //_matchService = matchService;
        }

        public Dictionary<string, List<Team>> RafflesOctavesFinal(List<Team> selections)
        {
            var rnd = new Random();                    

            var key_1 = new List<Team>();
            var key_2 = new List<Team>();
            var key_3 = new List<Team>();
            var key_4 = new List<Team>();
            var key_5 = new List<Team>();
            var key_6 = new List<Team>();
            var key_7 = new List<Team>();
            var key_8 = new List<Team>();            

            for (int i = 0; i < 2; i++)
            {
                if (key_1.Count < 2)
                {                    
                    var selected = rnd.Next(0, selections.Count());
                    key_1.Add(selections[selected]);
                    //selections.RemoveAt(selected);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();

                }
                if (key_2.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_2.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }
                if (key_3.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_3.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }
                if (key_4.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_4.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }
                if (key_5.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_5.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }
                if (key_6.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_6.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }
                if (key_7.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_7.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }
                if (key_8.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_8.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }

            }

            var rafflesOctavesFinal = new Dictionary<string, List<Team>>
            {
                { "Key:1", key_1 },
                { "Key:2", key_2 },
                { "Key:3", key_3 },
                { "Key:4", key_4 },
                { "Key:5", key_5 },
                { "Key:6", key_6 },
                { "Key:7", key_7 },
                { "Key:8", key_8 }
            };
            
            return rafflesOctavesFinal;
        }

        public Dictionary<string, List<Team>> RafflesQuarterFinal(List<Team> selections)
        {
            var rnd = new Random();           

            //foreach (var item in _selectionsClassifiedQuarterFinal)
            //{
            //    _teamRepository.Add(item);
            //}

            //selections = _teamRepository.GetAll().ToList();

            var key_1 = new List<Team>();
            var key_2 = new List<Team>();
            var key_3 = new List<Team>();
            var key_4 = new List<Team>();

            for (int i = 0; i < 2; i++)
            {
                if (key_1.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_1.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();

                }
                if (key_2.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_2.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }
                if (key_3.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_3.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }
                if (key_4.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_4.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }

            }

            var rafflesQuarterFinal = new Dictionary<string, List<Team>>
            {
                { "Key:1", key_1 },
                { "Key:2", key_2 },
                { "Key:3", key_3 },
                { "Key:4", key_4 }
            };

            return rafflesQuarterFinal;
            
        }

        public Dictionary<string, List<Team>> RafflesSemiFinal(List<Team> selections)
        {
            var rnd = new Random();            

            var key_1 = new List<Team>();
            var key_2 = new List<Team>();            

            for (int i = 0; i < 2; i++)
            {
                if (key_1.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_1.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();

                }
                if (key_2.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count());
                    key_2.Add(selections[selected]);
                    _teamRepository.Remove(selections[selected].TeamId);
                    selections = _teamRepository.GetAll().ToList();
                }                

            }

            var rafflesSemiFinal = new Dictionary<string, List<Team>>
            {
                { "Key:1", key_1 },
                { "Key:2", key_2 }                
            };

            return rafflesSemiFinal;
        }
    }
}
