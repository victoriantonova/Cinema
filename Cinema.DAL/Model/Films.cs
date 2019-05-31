using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DAL.Model
{
    public class Films
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        //public ICollection<GenresOfFilm> GenresOfFilms { get; set; }

    }
}
