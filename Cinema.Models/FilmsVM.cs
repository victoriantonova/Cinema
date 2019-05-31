using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    public class FilmsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        //public ICollection<GenresOfFilmVM> GenresOfFilms { get; set; }

    }
}
