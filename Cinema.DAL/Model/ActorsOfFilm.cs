using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DAL.Model
{
    public class ActorsOfFilm
    {
        public int Id { get; set; }
        public int IdFilm { get; set; }
        [ForeignKey("IdFilm")]
        public virtual Films Films { get; set; }
        public int IdActor { get; set; }
        [ForeignKey("IdActor")]
        public virtual Actors Actors { get; set; }
    }
}
