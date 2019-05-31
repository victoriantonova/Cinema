using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    public class OrdersVM
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public virtual ApplicationUserVM Users { get; set; }
        public int IdSeance { get; set; }
        public virtual SeancesVM Seances { get; set; }
        public int IdSeat { get; set; }
        public bool Ispaid { get; set; }
    }
}
