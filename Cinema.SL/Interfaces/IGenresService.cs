using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Interfaces
{
    public interface IGenresService
    {
        List<GenresVM> GetAll();
        GenresVM FindById(int genreId);
    }
}
