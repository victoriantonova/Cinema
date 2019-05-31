using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.DAL.Repositories
{
    public class GenresRepository : IRepository<Genres>
    {
        private readonly DatabaseContext _context;

        public GenresRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Genres> GetAll()
        {
            return _context.Genres;
        }

        public Genres Get(int id)
        {
            return _context.Genres.Find(id);
        }

        public void Create(Genres genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void Update(Genres genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Genres> Find(Func<Genres, Boolean> predicate)
        {
            return _context.Genres.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Genres genre = _context.Genres.Find(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
        }
    }
}
