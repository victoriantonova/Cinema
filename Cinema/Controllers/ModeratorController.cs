using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.DAL.Model;
using Cinema.Models;
using Cinema.SL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class ModeratorController : Controller
    {
        private readonly ICinemasService _cinemasService;
        private readonly IFilmsService _filmsService;


        public ModeratorController(ICinemasService cinemasService, IFilmsService filmsService)
        {
            _cinemasService = cinemasService;
            _filmsService = filmsService;
        }

        [Authorize(Roles = "Moderator")]
        public IActionResult Index(int? cinemaId, int? filmId)
        {
            List<FilmsVM> films = new List<FilmsVM>();
            List<CinemasVM> cinemas = new List<CinemasVM>();

            if (cinemaId.HasValue)
            {
                cinemas.AddRange(ViewBag.Cinemas);
            }
            else
            {
                cinemas = _cinemasService.GetAll();
                ViewBag.Cinemas = cinemas;
            }

            if (filmId.HasValue)
            {
                films.AddRange(ViewBag.Films);
            }
            else
            {
                films = _filmsService.GetAll();
                ViewBag.Films = films;
            }

            SeancesViewModel seancesViewModel = new SeancesViewModel
            {
                CurrentCinemaId = cinemaId,
                CurrentFilmId = filmId,
                Cinemas = cinemas,
                Films = films
            };

            return View(seancesViewModel);
        }
    }
}