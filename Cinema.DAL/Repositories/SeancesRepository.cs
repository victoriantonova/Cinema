using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repositories
{
    public class SeancesRepository : IRepository<Seances>
    {
        private readonly DatabaseContext _context;

        public SeancesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Seances> GetAll()
        {
            return _context.Seances;
        }
        public IEnumerable<Seances> GetAllId()
        {
            return _context.Seances.Include(i => i.Id);
        }
        public IEnumerable<Seances> GetAllA()
        {
            //    var seances = db.Seances.Join(db.Films, // второй набор
            //            idf => idf.Id_Film, // свойство-селектор объекта из первого набора
            //            idff => idff.id_film, // свойство-селектор объекта из второго набора
            //   (idf, idff) => new // результат
            //   { idf, idff})
            //   .Select( s => new
            //        s.idf.Id_Seance,
            //        idf.Id_Film,
            //        s.idff.name_film,
            //        s.idf.Id_Cinema,
            //        s.idf.Count_Seats,
            //        s.idf.AllSeats,
            //        s.idf.Date_Seance,
            //        s.idf.Time_Seance
            //   });.AsQueryable();
            //var se = seances.ToList(); 
            //        return seances;

            return _context.Seances;
        }

        public Seances getDateofSeance(int entered_idseance)
        {
            return _context.Seances.Include(d => d.DateSeance).Include(t => t.TimeSeance).Where(id => id.Id.Equals(entered_idseance)).FirstOrDefault();
            //Include(d => d.Date_Seance).Include(t=>t.Time_Seance);
        }

        public Seances Get(int id)
        {
            Seances seances = _context.Seances.Where(i => i.Id.Equals(id)).FirstOrDefault();
            return seances;
        }

        public Task<Seances> GetId(int id_cinema, int id_film, DateTime date, TimeSpan time)
        {
            return _context.Seances.FirstOrDefaultAsync(id => id.IdCinema.Equals(id_cinema) && id.IdFilm.Equals(id_film) && id.DateSeance.Equals(date) && id.TimeSeance.Equals(time));
        }
        
        public void Create(Seances seance)
        {
            //_context.Entry(seance).State = EntityState.Added;
            //return _context.SaveChangesAsync();
            _context.Seances.Add(seance);
            _context.SaveChanges();
        }

        public void Update(Seances seance)
        {
            _context.Entry(seance).Property(c => c.Price).IsModified = true;
            _context.SaveChanges();
            //return _context.SaveChanges();
        }

        public IEnumerable<Seances> Find(Func<Seances, Boolean> predicate)
        {
            return _context.Seances.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Seances seances = _context.Seances.Where(i => i.Id.Equals(id)).FirstOrDefault();
            if (seances == null)
            {
                throw new Exception("Нечего удалять");
            }
            else
            {
                _context.Seances.Remove(seances);
                _context.SaveChanges();
            }

        }
    }
}
