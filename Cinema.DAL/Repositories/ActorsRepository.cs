using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.DAL.Repositories
{
    public class ActorsRepository : IRepository<Actors>
    {
        private readonly DatabaseContext _context;

        public ActorsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Actors> GetAll()
        {
            return _context.Actors;
        }

        public Actors Get(int id)
        {
            return _context.Actors.Find(id);
        }

        public void Create(Actors actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Update(Actors actor)
        {
            _context.Entry(actor).State = EntityState.Modified;
        }

        public IEnumerable<Actors> Find(Func<Actors, Boolean> predicate)
        {
            return _context.Actors.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Actors actor = _context.Actors.Find(id);
            if (actor != null)
                _context.Actors.Remove(actor);
        }
    }
}
