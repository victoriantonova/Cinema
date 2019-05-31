using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.DAL.Repositories
{
    public class FilmsRepository : IRepository<Films>
    {
        private readonly DatabaseContext _context;

        public FilmsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Films> GetAll()
        {
            return _context.Films;
        }

        public Films Get(int id)
        {
            return _context.Films.Find(id);
        }

        public void Create(Films film)
        {
            _context.Films.Add(film);
            _context.SaveChanges();
        }

        public void Update(Films film)
        {
            //_context.Entry(film).State = EntityState.Modified;
            Films result = Get(film.Id);
            if (result != null)
            {
                result.Name = film.Name;
                result.Year = film.Year;
                result.Duration = film.Duration;
                result.Description = film.Description;
                result.Img = film.Img;
                result.DateStart = film.DateStart;
                result.DateEnd = film.DateEnd;

                _context.SaveChanges();
            }
        }

        public IEnumerable<Films> Find(Func<Films, Boolean> predicate)
        {
            return _context.Films.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Films film = _context.Films.Find(id);
            if (film != null)
            {
                _context.Films.Remove(film);
                _context.SaveChanges();
            }
        }
    }
}
