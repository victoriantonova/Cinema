using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    public class ActorsOfFilmVM
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        public int IdActor { get; set; }

        public virtual FilmsVM Films { get; set; }
        public virtual ActorsVM Actors { get; set; }
    }
}
