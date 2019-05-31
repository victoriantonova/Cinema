using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.DAL.Model
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int IdSeance { get; set; }
       
        public int IdSeat { get; set; }
        public bool Ispaid { get; set; }

        [ForeignKey("IdSeance")]
        public virtual Seances Seances { get; set; }
        [ForeignKey("IdUser")]
        public virtual ApplicationUser Users { get; set; }

    }
}
