using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Interfaces
{
    public interface IActorsOfFilmService
    {
        List<ActorsOfFilmVM> GetAll();
        ActorsOfFilmVM FindById(int gfId);
        List<ActorsOfFilmVM> FindActorsByIdFilm(int gfId);
        List<ActorsOfFilmVM> FindFilmssByIdActor(int actorId);
    }
}
