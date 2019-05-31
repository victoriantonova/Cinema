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
    [Route("api/[controller]")]
    [ApiController]
    public class GenresOfFilmAPIController : ControllerBase
    {
        private IGenresOfFilmService _genresOfFilmService;

        public GenresOfFilmAPIController(IGenresOfFilmService genresOfFilmService)
        {
            _genresOfFilmService = genresOfFilmService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GenresOfFilmVM>> Get()
        {
            return _genresOfFilmService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<GenresOfFilmVM>> Get(int id)
        {
            //return _genresOfFilmService.FindById(id);

            return _genresOfFilmService.FindGenresByIdFilm(id);
        }
    }
}