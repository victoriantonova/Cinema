﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.DAL;
using Cinema.DAL.Model;
using Cinema.SL.Interfaces;
using Cinema.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeancesController : ControllerBase
    {
        private readonly ISeanceService _seanceService;
        private readonly ICinemasService _cinemasService;
        private readonly IFilmsService _filmsService;

        public SeancesController(ISeanceService seanceService, ICinemasService cinemasService, IFilmsService filmsService)
        {
            _seanceService = seanceService;
            _cinemasService = cinemasService;
            _filmsService = filmsService;
        }

        // GET: api/Seances
        //[HttpGet]
        //public IEnumerable<Seances> GetSeances()
        //{
        //    return _seanceService.getSeancesIds();
        //}

        [HttpGet]
        public IEnumerable<SeanceInfo> GetSeances()
        {
            List<SeanceInfo> seancei = new List<SeanceInfo>();
            var seances = _seanceService.GetAllSeances().ToList();
            foreach (Seances seance in seances)
            {
                if (DateTime.Now <= seance.DateSeance)
                {
                    var cinemasinfo = _cinemasService.getCinemaofSeance(seance.IdCinema);
                    var filmsinfo = _filmsService.getFilmofSeance(seance.IdFilm);

                    seancei.Add(new SeanceInfo
                    {
                        SeanceId = seance.Id,
                        CinemaId = seance.IdCinema,
                        CinemaName = cinemasinfo.Name,
                        FilmId = seance.IdFilm,
                        FilmName = filmsinfo.Name,
                        DateSeance = seance.DateSeance,
                        TimeSeance = seance.TimeSeance,
                        Price = seance.Price,
                        CountSeats = seance.Count_Seats
                    });
                }
            }
            return seancei;
        }


        // GET: api/Seances/5
        [HttpGet("{idfilm}")]
        public IEnumerable<SeanceInfo> GetSeances(int idfilm)
        {
            List <SeanceInfo> seancei = new List<SeanceInfo>();
            var seances = _seanceService.getSeanceInfoOfIdFilm(idfilm).ToList();
            foreach (Seances seance in seances)
            {
                if (DateTime.Now <= seance.DateSeance)
                {
                    var cinemasinfo = _cinemasService.getCinemaofSeance(seance.IdCinema);
                    var filmsinfo = _filmsService.getFilmofSeance(seance.IdFilm);

                    seancei.Add(new SeanceInfo
                    {
                        SeanceId = seance.Id,
                        CinemaId = seance.IdCinema,
                        CinemaName = cinemasinfo.Name,
                        FilmId = seance.IdFilm,
                        FilmName = filmsinfo.Name,
                        DateSeance = seance.DateSeance,
                        TimeSeance = seance.TimeSeance,
                        Price = seance.Price,
                        CountSeats = seance.Count_Seats
                    });
                }
            }
            return seancei;
        }

        //// PUT: api/Seances/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSeances(int id, Seances seances)
        //{
        //    if (id != seances.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(seances).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SeancesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Seances
        [Authorize(Roles = "Moderator")]
        [HttpPost]
        public ActionResult PostSeances([FromForm] Seances seances)
        {
            try { 
            if (seances.IdCinema == 0)
            {                    
                    throw new Exception("ex");
            }
            else
            {
                _seanceService.CreateSeance(seances);
                return RedirectToAction("Index", "Moderator");
            } 
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // DELETE: api/Seances/5
        [Authorize(Roles = "Moderator")]
        [HttpDelete("{id}")]
        public void DeleteSeances(int id)
        {
            _seanceService.DeleteSeance(Convert.ToInt32(id));
            //return RedirectToAction("Index","Moderator") ;
        }




        //    private bool SeancesExists(int id)
        //    {
        //        return _context.Seances.Any(e => e.Id == id);
        //    }
    }
}
