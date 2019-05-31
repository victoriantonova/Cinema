using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.DAL.Repositories
{
    class GenresOfFilmRepository : IRepository<GenresOfFilm>
    {
        private readonly DatabaseContext _context;

        public GenresOfFilmRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<GenresOfFilm> GetAll()
        {
            return _context.GenresOfFilm.Include(x => x.Films).Include(x => x.Genres);
        }

        //public IEnumerable<GenresOfFilm> GetGenresFilm(int id)
        //{
        //    return _context.GenresOfFilm.Include(x => x.Films).Include(x => x.Genres).Where(x => x.IdFilm == id);
        //}

        public GenresOfFilm Get(int id)
        {
            //return _context.GenresOfFilm.Find(id);
            var o = _context.GenresOfFilm.FirstOrDefault(x => x.Id == id);
            if (o != null)
            {
                o.Films = _context.Films.FirstOrDefault(x => x.Id == o.IdFilm);
                o.Genres = _context.Genres.FirstOrDefault(x => x.Id == o.IdGenre);
            }

            return o;
        }

        public void Create(GenresOfFilm genre)
        {
            _context.GenresOfFilm.Add(genre);
            _context.SaveChanges();
        }

        public void Update(GenresOfFilm genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<GenresOfFilm> Find(Func<GenresOfFilm, Boolean> predicate)
        {
            return _context.GenresOfFilm.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            GenresOfFilm genre = _context.GenresOfFilm.Find(id);
            if (genre != null)
            {
                _context.GenresOfFilm.Remove(genre);
                _context.SaveChanges();
            }
        }
    }
}
