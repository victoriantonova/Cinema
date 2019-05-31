using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Interfaces
{
    public interface IGenresOfFilmService
    {
        List<GenresOfFilmVM> GetAll();
        GenresOfFilmVM FindById(int gfId);
        List<GenresOfFilmVM> FindGenresByIdFilm(int gfId);

    }
}
