using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DAL.Model
{
    public class Cinemas
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int CountSeats { get; set; }

    }
}