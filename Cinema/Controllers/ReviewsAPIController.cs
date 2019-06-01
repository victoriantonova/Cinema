using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Models;
using Cinema.SL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsAPIController : ControllerBase
    {
        private IReviewsService _reviewsService;

        public ReviewsAPIController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewsVM>> Get()
        {
            return _reviewsService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ReviewsVM>> Get(int id)
        {
            //return _genresOfFilmService.FindById(id);

            return _reviewsService.GetReviewsByIdFilm(id);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public void Post([FromBody]ReviewsVM value)
        {
            value.IdAuthor = UserHelper.IdUser;
            _reviewsService.Create(value);
        }
    }
}