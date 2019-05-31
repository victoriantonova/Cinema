using Cinema.DAL.Model;
using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Interfaces
{
    public interface ICinemasService
    {
        List<CinemasVM> GetAll();
        CinemasVM FindById(int cId);
        IEnumerable<Cinemas> GetAllFilms();
        Cinemas GetFilmById(int id);
        void AddCinema(Cinemas cinema);
        IEnumerable<Cinemas> getCinemaInfoOfSeanceId(int idfilm);
        Cinemas getCinemaofSeance(int idcinema);

    }
}
