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
using Microsoft.AspNetCore.Authorization;
using Cinema.Models;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICinemasService _cinemasService;
        private readonly IFilmsService _filmsService;
        private readonly ISeanceService _seanceService;


        public OrdersController(IOrderService orderService, ICinemasService cinemasService, IFilmsService filmsService, ISeanceService seanceService)
        {
            _orderService = orderService;
            _cinemasService = cinemasService;
            _filmsService = filmsService;
            _seanceService = seanceService;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Orders> GetOrders()
        {
            return _orderService.getOrders();
        }

        // GET: api/Orders/iduser
        [HttpGet("{iduser}")]
        public async Task<IActionResult> GetOrders(string iduser)
        {
            var orders = await Task.Run(()=>_orderService.getOrdersId(iduser));

            if (orders == null)
            {
                return NotFound();
            }

            List<OrdersInfoVM> ordersInfo = new List<OrdersInfoVM>();

            foreach(Orders ord in orders)
            {
               
                var seanceinfo = _seanceService.getSeanceofOrder(ord.IdSeance);

                foreach (Seances seance in seanceinfo)
                {
                    var cinemasinfo = _cinemasService.getCinemaofSeance(seance.IdCinema);
                    var filmsinfo = _filmsService.getFilmofSeance(seance.IdFilm);

                    ordersInfo.Add(new OrdersInfoVM
                    {
                        OrderId = ord.Id,
                        CinemaId = cinemasinfo.Id,
                        CinemaName = cinemasinfo.Name,
                        FilmId = filmsinfo.Id,
                        FilmName = filmsinfo.Name,
                        DateSeance = seance.DateSeance,
                        TimeSeance = seance.TimeSeance,
                        Price = seance.Price,
                        SeanceId = seance.Id,
                        PlaceNumber = ord.IdSeat
                    });
                }
            }
            //return Ok(orders);
            return Ok(ordersInfo);
        }




        // PUT: api/Orders/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrders(int id, Orders orders)
        //{
        //    if (id != orders.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(orders).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrdersExists(id))
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

        // POST: api/Orders
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostOrder([FromBody] Orders order)
        {
            if(order == null)
            {
                return BadRequest(ModelState);
            }

            order.IdUser = UserHelper.IdUser;
            try
            {
                await Task.Run(() => _orderService.CreateOrder(order));
                return Ok(order);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        //[HttpDelete]
        public ActionResult DeleteOrders(string id)//[FromBody]int id)
        {
            _orderService.DeleteOrder(Convert.ToInt32(id));
            //return RedirectToAction("UserOrders","Booking") ;
            return Ok();

        }

        //private bool OrdersExists(int id)
        //{
        //    return _context.Orders.Any(e => e.Id == id);
        //}
    }
}
