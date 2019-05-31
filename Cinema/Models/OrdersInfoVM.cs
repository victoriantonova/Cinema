using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class OrdersInfoVM
    {
        public int OrderId { get; set; }
        public int SeanceId { get; set; }
        public int CinemaId { get; set; }
        public string CinemaName { get; set; }
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public DateTime DateSeance { get; set; }
        public TimeSpan TimeSeance { get; set; }
        public int Price { get; set; }
        public int PlaceNumber { get; set; }

    }
}
