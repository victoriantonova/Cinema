using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.DAL.Repositories
{
    public class CinemasRepository : IRepository<Cinemas>
    {
        private readonly DatabaseContext _context;

        public CinemasRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Cinemas> GetAll()
        {
            return _context.Cinemas;
        }

        public Cinemas Get(int id)
        {
            return _context.Cinemas.Find(id);
        }

        public void Create(Cinemas genre)
        {
            _context.Cinemas.Add(genre);
            _context.SaveChanges();
        }

        public void Update(Cinemas c)
        {
            _context.Entry(c).State = EntityState.Modified;
        }

        public IEnumerable<Cinemas> Find(Func<Cinemas, Boolean> predicate)
        {
            return _context.Cinemas.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Cinemas c = _context.Cinemas.Find(id);
            if (c != null)
            {
                _context.Cinemas.Remove(c);
                _context.SaveChanges();
            }
        }
    }
}
