using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Films()
        {
            return View();
        }
    }
}