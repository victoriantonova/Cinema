using Cinema.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class SeancesViewModel
    {
        public int? CurrentCinemaId { get; set; }
        public int? CurrentFilmId { get; set; }
        public List<CinemasVM> Cinemas { get; set; }
        public List<FilmsVM> Films { get; set; }

    }
}
