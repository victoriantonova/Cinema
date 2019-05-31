using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Interfaces
{
    public interface IReviewsService
    {
        List<ReviewsVM> GetAll();
        //ReviewsVM FindById(int gfId);
        List<ReviewsVM> GetReviewsByIdFilm(int gfId);
        void Create(ReviewsVM review);
    }
}
