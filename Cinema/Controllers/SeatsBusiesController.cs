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

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsBusiesController : ControllerBase
    {
        private readonly ISeatsBusyService _seatBusyService;

        public SeatsBusiesController(ISeatsBusyService seatsBusyService)
        {
            _seatBusyService = seatsBusyService;
        }

        // GET: api/SeatsBusies
        [HttpGet]
        public IEnumerable<SeatsBusy> GetSeatsBusy()
        {
            return _seatBusyService.getSeatsBusy();
        }

        // GET: api/SeatsBusies/5
        [HttpGet("{idseance}")]
        public IEnumerable<SeatsBusy> GetSeatsBusy(int idseance)
        {
            return  _seatBusyService.getSeatsBusyIdSeance(idseance);    
            
        }

        // PUT: api/SeatsBusies/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSeatsBusy(int id, SeatsBusy seatsBusy)
        //{
        //    if (id != seatsBusy.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(seatsBusy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SeatsBusyExists(id))
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

        //// POST: api/SeatsBusies
        //[HttpPost]
        //public async Task<ActionResult<SeatsBusy>> PostSeatsBusy(SeatsBusy seatsBusy)
        //{
        //    _context.SeatsBusy.Add(seatsBusy);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSeatsBusy", new { id = seatsBusy.Id }, seatsBusy);
        //}

        //// DELETE: api/SeatsBusies/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<SeatsBusy>> DeleteSeatsBusy(int id)
        //{
        //    var seatsBusy = await _context.SeatsBusy.FindAsync(id);
        //    if (seatsBusy == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.SeatsBusy.Remove(seatsBusy);
        //    await _context.SaveChangesAsync();

        //    return seatsBusy;
        //}

        //private bool SeatsBusyExists(int id)
        //{
        //    return _context.SeatsBusy.Any(e => e.Id == id);
        //}
    }
}
