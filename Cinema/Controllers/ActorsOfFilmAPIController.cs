using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Models;
using Cinema.SL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorsOfFilmAPIController : ControllerBase
    {
        private IActorsOfFilmService _actorsOfFilmService;

        public ActorsOfFilmAPIController(IActorsOfFilmService actorsOfFilmService)
        {
            _actorsOfFilmService = actorsOfFilmService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ActorsOfFilmVM>> Get()
        {
            return _actorsOfFilmService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ActorsOfFilmVM>> Get(int id)
        {
            return _actorsOfFilmService.FindActorsByIdFilm(id);
        }


        [HttpGet("{idactor}")]
        public ActionResult<IEnumerable<ActorsOfFilmVM>> GetFilms(int idactor)
        {
            return _actorsOfFilmService.FindFilmssByIdActor(idactor);

        }
    }
}