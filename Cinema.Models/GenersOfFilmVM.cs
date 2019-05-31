using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    public class GenresOfFilmVM
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        public int IdGenre { get; set; }

        public virtual FilmsVM Films { get; set; }
        public virtual GenresVM Genres { get; set; }
    }
}
