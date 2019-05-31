using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    public class SeancesVM
    {
        public int Id { get; set; }
        public int IdCinema { get; set; }
        public int IdFilm { get; set; }
        public int Count_Seats { get; set; }
        public DateTime DateSeance { get; set; }
        public TimeSpan TimeSeance { get; set; }
        public int AllSeats { get; set; }
        public int Price { get; set; }

        public virtual CinemasVM Cinemas { get; set; }
        public virtual FilmsVM Films { get; set; }
    }
}
