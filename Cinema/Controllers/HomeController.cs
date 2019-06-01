using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinema.SL.Interfaces;
using Cinema.DAL.Model;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmsService _filmsService;
        private readonly IActorsService _actorsService;
        private readonly IActorsOfFilmService _actorsOfFilmService;


        public HomeController(IActorsService actorsService, IActorsOfFilmService actorsOfFilmService)
        {
            _actorsService = actorsService;
            _actorsOfFilmService = actorsOfFilmService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: home/Details/5
        public ActionResult Details(int id)
        {
            ViewData["Id"] = id;
            UserHelper.IdFilm = id;
            return View();
        }

        public IActionResult FindFilms(int? id)
        {
            var films = _actorsOfFilmService.FindFilmssByIdActor(id.Value);
            //SelectList actors = new SelectList(_actorsService.GetAll(), "Id", "Name");
            //ViewBag.Actors = actors;

            return View(films);
        }
    }
}
