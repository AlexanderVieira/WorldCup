using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WorldCup.Application.Interfaces;
using WorldCup.Domain.Entities;

namespace WorldCup.Presentation.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamAppService _teamAppService;
        private readonly IMatchAppService _matchAppService;
        private readonly IRafflesAppService _rafflesAppService;

        public TeamController(ITeamAppService teamAppService,
            IMatchAppService matchAppService, IRafflesAppService rafflesAppService)
        {
            _teamAppService = teamAppService;
            _matchAppService = matchAppService;
            _rafflesAppService = rafflesAppService;
        }


        // GET: Team
        public ActionResult Index()
        {
            //################################################# OITAVAS DE FINAL ############################################

            _teamAppService.Add(new Team("Brasil", "BRA"));
            _teamAppService.Add(new Team("Argentina", "ARG"));
            _teamAppService.Add(new Team("Uruguai", "URU"));
            _teamAppService.Add(new Team("Colombia", "COL"));
            _teamAppService.Add(new Team("Paraguai", "PAR"));
            _teamAppService.Add(new Team("Alemanha", "ALE"));
            _teamAppService.Add(new Team("Holanda", "HOL"));
            _teamAppService.Add(new Team("Espanha", "ESP"));
            _teamAppService.Add(new Team("Inglaterra", "ING"));
            _teamAppService.Add(new Team("Belgica", "BEL"));
            _teamAppService.Add(new Team("Croacia", "CRO"));
            _teamAppService.Add(new Team("Italia", "ITA"));
            _teamAppService.Add(new Team("Marrocos", "MAR"));
            _teamAppService.Add(new Team("Nigeria", "NIG"));
            _teamAppService.Add(new Team("Mexico", "Mex"));
            _teamAppService.Add(new Team("Costa Rica", "COS"));

            // LISTA DE SELECOES OITAVAS DE FINAL - SORTEIO
            var selections = _teamAppService.GetAll().ToList();                        
            var selectionsRafflesOctavesFinals = _rafflesAppService.RafflesOctavesFinal(selections);
            
            // CONFRONTOS OITAVAS DE FINAL
            var resultOctavesFinal = _matchAppService.PlayOctavesFinal(selectionsRafflesOctavesFinals);

            // VENCEDORES OITAVAS DE FINAL
            ViewBag.resultOctavesFinal = resultOctavesFinal;
            var winnersOctaves = resultOctavesFinal.Values.ElementAt(0);
            var disqualifiedsOctaves = resultOctavesFinal.Values.ElementAt(1);

            //################################################# QUARTAS DE FINAL ##############################################

            ViewBag.classifiedSelectionsForQuarterFinals = resultOctavesFinal;

            // VENCEDORES DAS OITAVAS DE FINAL - SORTEIO
            var selectionsRafflesQuarterFinals = _rafflesAppService.RafflesQuarterFinal(winnersOctaves);
            ViewBag.selectionsRafflesQuarterFinals = selectionsRafflesQuarterFinals;

            // CONFRONTOS QUARTAS DE FINAL
            var classifiedSelectionsForSemiFinal = _matchAppService.PlayQuarterFinal(selectionsRafflesQuarterFinals);

            // VENCEDORES DAS QUARTAS DE FINAL - SORTEIO
            var winnersQuarters = classifiedSelectionsForSemiFinal.Values.ElementAt(0);
            var disqualifiedsQuarters = classifiedSelectionsForSemiFinal.Values.ElementAt(1);

            //#################################################### SEMI-FINAL #################################################
                        
            ViewBag.classifiedSelectionsForSemiFinals = classifiedSelectionsForSemiFinal;
            var selectionsRafflesSemiFinals = _rafflesAppService.RafflesSemiFinal(winnersQuarters);
            ViewBag.selectionsRafflesSemiFinals = selectionsRafflesSemiFinals;

            // VENCEDORES DAS SEMI-FINAIS
            var classifiedSelectionsForFinal = _matchAppService.PlaySemiFinal(selectionsRafflesSemiFinals);

            // VENCEDORES DAS SEMI DE FINAIS
            var winnersSemiFinal = classifiedSelectionsForFinal.Values.ElementAt(0);
            var disqualifiedsSemiFinal = classifiedSelectionsForFinal.Values.ElementAt(1);

            //###################################################### FINAL ####################################################

            ViewBag.classifiedSelectionsForFinal = classifiedSelectionsForFinal;
            var selectionChampion = _matchAppService.PlayFinal(winnersSemiFinal);

            return View();
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Team/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Team/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}