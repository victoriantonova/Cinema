using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Interfaces
{
    public interface IActorsService
    {
        List<ActorsVM> GetAll();
        ActorsVM FindById(int genreId);
    }
}
