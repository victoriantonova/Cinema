using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    public class CinemasVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int CountSeats { get; set; }

    }
}
