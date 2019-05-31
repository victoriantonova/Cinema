using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.DAL.Repositories
{
    public class ActorsOfFilmRepository : IRepository<ActorsOfFilm>
    {
        private readonly DatabaseContext _context;

        public ActorsOfFilmRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<ActorsOfFilm> GetAll()
        {
            return _context.ActorsOfFilm.Include(x => x.Films).Include(x => x.Actors);
        }

        public ActorsOfFilm Get(int id)
        {
            //return _context.ActorsOfFilm.Find(id);
            var o = _context.ActorsOfFilm.FirstOrDefault(x => x.Id == id);
            if (o != null)
            {
                o.Films = _context.Films.FirstOrDefault(x => x.Id == o.IdFilm);
                o.Actors = _context.Actors.FirstOrDefault(x => x.Id == o.IdActor);
            }

            return o;
        }

        public void Create(ActorsOfFilm actor)
        {
            _context.ActorsOfFilm.Add(actor);
            _context.SaveChanges();
        }

        public void Update(ActorsOfFilm actor)
        {
            _context.Entry(actor).State = EntityState.Modified;
        }

        public IEnumerable<ActorsOfFilm> Find(Func<ActorsOfFilm, Boolean> predicate)
        {
            return _context.ActorsOfFilm.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ActorsOfFilm actor = _context.ActorsOfFilm.Find(id);
            if (actor != null)
                _context.ActorsOfFilm.Remove(actor);
        }
    }
}
