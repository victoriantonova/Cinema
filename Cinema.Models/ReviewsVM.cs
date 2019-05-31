using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Models
{
    public class ReviewsVM
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        public string IdAuthor { get; set; }
        public DateTime Date { get; set; }
        public string Feedback { get; set; }

        public virtual FilmsVM Films { get; set; }
        public virtual ApplicationUserVM Users { get; set; }


    }
}
