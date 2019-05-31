using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.SL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class BookingController : Controller
    {
        private readonly ISeatsBusyService _seatBusyService;
        private readonly IOrderService _orderService;


        public BookingController(ISeatsBusyService seatsBusyService, IOrderService orderService)
        {
            _seatBusyService = seatsBusyService;
            _orderService = orderService;
        }
        public IActionResult Index(int id)
        {
            ViewData["Id"] = id;
            var seatsBust = _seatBusyService.getSeatsBusyIdSeance(id);
            return View(seatsBust);
        }

        public IActionResult UserOrders(string id)
        {
            ViewData["Id"] = id;
            var order = _orderService.getOrdersId(id);
            return View(order);
        }
    }
}