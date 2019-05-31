using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.DAL.Model
{
    public class Seances
    {
        [Key]
        public int Id { get; set; }
       
        public int IdCinema { get; set; }
      

        public int IdFilm { get; set; }
        public int Count_Seats { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateSeance { get; set; }
        public TimeSpan TimeSeance { get; set; }
        public int AllSeats { get; set; }
        public int Price { get; set; }
        [ForeignKey("IdCinema")]
        public virtual Cinemas Cinemas { get; set; }

        [ForeignKey("IdFilm")]
        public virtual Films Films { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<SeatsBusy> Seats_Busy { get; set; }
    }
}
