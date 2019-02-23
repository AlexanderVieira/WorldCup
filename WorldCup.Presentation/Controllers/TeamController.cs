using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCup.Application.Interfaces;

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
            //################################ OITAVAS DE FINAL ###################################

            var selectionsRafflesOctavesFinals = _rafflesAppService.RafflesOctavesFinal();
            ViewBag["selectionsRafflesOctavesFinals"] = selectionsRafflesOctavesFinals;            
            var classifiedSelectionsForQuarterFinals = _matchAppService.PlayOctavesFinal();

            //################################ QUARTAS DE FINAL ###################################
            
            ViewBag["classifiedSelectionsForQuarterFinals"] = classifiedSelectionsForQuarterFinals;
            var selectionsRafflesQuarterFinals = _rafflesAppService.RafflesQuarterFinal();
            ViewBag["selectionsRafflesQuarterFinals"] = selectionsRafflesQuarterFinals;
            var classifiedSelectionsForSemiFinal = _matchAppService.PlayQuarterFinal();

            //#################################### SEMI-FINAL #####################################

            ViewBag["classifiedSelectionsForSemiFinals"] = classifiedSelectionsForSemiFinal;
            var selectionsRafflesSemiFinals = _rafflesAppService.RafflesSemiFinal();
            ViewBag["selectionsRafflesSemiFinals"] = selectionsRafflesSemiFinals;
            var classifiedSelectionsForFinal = _matchAppService.PlaySemiFinal();

            //#################################### SEMI-FINAL #####################################

            ViewBag["classifiedSelectionsForFinals"] = classifiedSelectionsForFinal;
            var selectionChampion = _matchAppService.PlayFinal();

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