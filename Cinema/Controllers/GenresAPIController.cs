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
    public class GenresAPIController : ControllerBase
    {
        private IGenresService _genresService;

        public GenresAPIController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GenresVM>> Get()
        {
            return _genresService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<GenresVM> Get(int id)
        {
            return _genresService.FindById(id);
        }
    }
}