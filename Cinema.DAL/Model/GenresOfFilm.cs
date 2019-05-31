using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.DAL.Model
{
    public class GenresOfFilm
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        [ForeignKey("IdFilm")]
        public virtual Films Films { get; set; }
        public int IdGenre { get; set; }
        [ForeignKey("IdGenre")]
        public virtual Genres Genres { get; set; }
    }
}
