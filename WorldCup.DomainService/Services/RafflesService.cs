using System;
using System.Collections.Generic;
using System.Linq;
using WorldCup.Domain.Entities;
using WorldCup.DomainService.Interfaces;

namespace WorldCup.DomainService.Services
{
    public class RafflesService : IRafflesService
    {
        private readonly ITeamService _teamService;

        public RafflesService(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public Dictionary<string, List<Team>> RafflesOctavesFinal()
        {
            _teamService.Add(new Team(1, "Brasil", "BRA"));
            _teamService.Add(new Team(2, "Argentina", "ARG"));
            _teamService.Add(new Team(3, "Uruguai", "URU"));
            _teamService.Add(new Team(4, "Colombia", "COL"));
            _teamService.Add(new Team(5, "Paraguai", "PAR"));
            _teamService.Add(new Team(6, "Alemanha", "ALE"));
            _teamService.Add(new Team(7, "Holanda", "HOL"));
            _teamService.Add(new Team(8, "Espanha", "ESP"));
            _teamService.Add(new Team(9, "Inglaterra", "ING"));
            _teamService.Add(new Team(10, "Belgica", "BEL"));
            _teamService.Add(new Team(11, "Croacia", "CRO"));
            _teamService.Add(new Team(12, "Italia", "ITA"));
            _teamService.Add(new Team(13, "Marrocos", "MAR"));
            _teamService.Add(new Team(14, "Nigeria", "NIG"));
            _teamService.Add(new Team(15, "Mexico", "Mex"));
            _teamService.Add(new Team(16, "Costa Rica", "COS"));

            var selections = _teamService.GetAll().ToList();

            //var selections = new List<Team>
            //{
            //    new Team(1, "Brasil", "BRA"),
            //    new Team(2, "Argentina", "ARG"),
            //    new Team(3, "Uruguai", "URU"),
            //    new Team(4, "Colombia", "COL"),
            //    new Team(5, "Paraguai", "PAR"),
            //    new Team(6, "Alemanha", "ALE"),
            //    new Team(7, "Holanda", "HOL"),
            //    new Team(8, "Espanha", "ESP"),
            //    new Team(9, "Inglaterra", "ING"),
            //    new Team(10, "Belgica", "BEL"),
            //    new Team(11, "Croacia", "CRO"),
            //    new Team(12, "Italia", "ITA"),
            //    new Team(13, "Marrocos", "MAR"),
            //    new Team(14, "Nigeria", "NIG"),
            //    new Team(15, "Mexico", "Mex"),
            //    new Team(16, "Costa Rica", "COS")
            //};

            var key_1 = new List<Team>();
            var key_2 = new List<Team>();
            var key_3 = new List<Team>();
            var key_4 = new List<Team>();
            var key_5 = new List<Team>();
            var key_6 = new List<Team>();
            var key_7 = new List<Team>();
            var key_8 = new List<Team>();

            var rnd = new Random();

            for (int i = 0; i < 2; i++)
            {
                if (key_1.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count);
                    key_1.Add(selections[selected]);
                    selections.RemoveAt(selected);

                }
                if (key_2.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count);
                    key_2.Add(selections[selected]);
                    selections.RemoveAt(selected);
                }
                if (key_3.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count);
                    key_3.Add(selections[selected]);
                    selections.RemoveAt(selected);
                }
                if (key_4.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count);
                    key_4.Add(selections[selected]);
                    selections.RemoveAt(selected);
                }
                if (key_5.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count);
                    key_5.Add(selections[selected]);
                    selections.RemoveAt(selected);
                }
                if (key_6.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count);
                    key_6.Add(selections[selected]);
                    selections.RemoveAt(selected);
                }
                if (key_7.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count);
                    key_7.Add(selections[selected]);
                    selections.RemoveAt(selected);
                }
                if (key_8.Count < 2)
                {
                    var selected = rnd.Next(0, selections.Count);
                    key_8.Add(selections[selected]);
                    selections.RemoveAt(selected);
                }

            }

            var rafflesOctavesFinal = new Dictionary<string, List<Team>>
            {
                { "Chave:1", key_1 },
                { "Chave:2", key_2 },
                { "Chave:3", key_3 },
                { "Chave:4", key_4 },
                { "Chave:5", key_5 },
                { "Chave:6", key_6 },
                { "Chave:7", key_7 },
                { "Chave:8", key_8 }
            };

            return rafflesOctavesFinal;
        }

        public Dictionary<string, List<Team>> RafflesQuarterFinal()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<Team>> RafflesSemiFinal()
        {
            throw new NotImplementedException();
        }
    }
}
