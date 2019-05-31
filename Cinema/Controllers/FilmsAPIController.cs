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
    public class FilmsAPIController : ControllerBase
    {
        private IFilmsService _filmsService;

        public FilmsAPIController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FilmsVM>> Get()
        {
            return _filmsService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<FilmsVM> Get(int id)
        {
            return _filmsService.FindById(id);
        }
    }
}