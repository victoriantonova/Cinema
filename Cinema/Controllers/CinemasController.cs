using System;
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
    public class CinemasController : ControllerBase
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            _cinemasService = cinemasService;
        }

        // GET: api/Cinemas
        [HttpGet]
        public IEnumerable<CinemasVM> GetCinemas()
        {
            return _cinemasService.GetAll();
        }

        // GET: api/Cinemas/5
        [HttpGet("{id}")]
        public IEnumerable<Cinemas> GetCinemas(int id)
        {
            var cinemas = _cinemasService.getCinemaInfoOfSeanceId(id);
            
                return cinemas;
        }

        // PUT: api/Cinemas/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCinemas(int id, Cinemas cinemas)
        //{
        //    if (id != cinemas.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cinemas).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CinemasExists(id))
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

        // POST: api/Cinemas
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostCinemas(Cinemas cinemas)
        {
            if(cinemas==null)
            {
                return BadRequest();
            }
            await Task.Run(() => _cinemasService.AddCinema(cinemas));
            return Ok(cinemas);
        }

        //// DELETE: api/Cinemas/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Cinemas>> DeleteCinemas(int id)
        //{
        //    var cinemas = await _context.Cinemas.FindAsync(id);
        //    if (cinemas == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cinemas.Remove(cinemas);
        //    await _context.SaveChangesAsync();

        //    return cinemas;
        //}

        //private bool CinemasExists(int id)
        //{
        //    return _context.Cinemas.Any(e => e.Id == id);
        //}
    }
}
