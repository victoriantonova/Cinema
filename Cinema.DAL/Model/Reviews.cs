using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.DAL.Model
{
    public class Reviews
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        [ForeignKey("IdFilm")]
        public virtual Films Films { get; set; }
        public string IdAuthor { get; set; }
        [ForeignKey("IdAuthor")]
        public virtual ApplicationUser Users { get; set; }
        public DateTime Date { get; set; }
        public string Feedback { get; set; }
    }
}
