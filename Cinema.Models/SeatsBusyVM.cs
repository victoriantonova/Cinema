using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    public class SeatsBusyVM
    {
        public int Id { get; set; }
        public int IdSeatbusy { get; set; }
        public int IdSeance { get; set; }
        public virtual SeancesVM Seances { get; set; }
        public bool Isbusy { get; set; }
    }
}
