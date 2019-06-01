using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class ActorsOfFilmViewModel
    {
        public int? IdActor { get; set; }
        public int? IdFilm { get; set; }
        public List<ActorsVM> Actors { get; set; }
        public List<FilmsVM> Films { get; set; }
    }
}
