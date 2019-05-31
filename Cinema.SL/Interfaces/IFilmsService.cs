using Cinema.DAL.Model;
using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Interfaces
{
    public interface IFilmsService
    {
        List<FilmsVM> GetAll();
        FilmsVM FindById(int filmId);
        Films getFilmofSeance(int idfilm);
    }
}
