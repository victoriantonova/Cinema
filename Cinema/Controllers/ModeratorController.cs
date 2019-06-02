using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.DAL.Model;
using Cinema.Models;
using Cinema.SL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult Index()
        {
                SelectList films = new SelectList(_filmsService.GetAll(), "Id", "Name");
                ViewBag.Films = films;

                SelectList cinemas = new SelectList(_cinemasService.GetAll(), "Id", "Name");
                ViewBag.Cinemas = cinemas;
            
            return View();
        }
    }
}