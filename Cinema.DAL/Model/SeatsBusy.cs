using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.DAL.Model
{
    public class SeatsBusy
    {
        [Key]
        public int Id { get; set; }
        public int IdSeatbusy { get; set; }
        public int IdSeance { get; set; }
        [ForeignKey("IdSeance")]
        public virtual Seances Seances { get; set; }
        public bool Isbusy { get; set; }
    }
}