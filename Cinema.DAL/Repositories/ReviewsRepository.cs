using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.DAL.Repositories
{
    public class ReviewsRepository : IRepository<Reviews>
    {
        private readonly DatabaseContext _context;

        public ReviewsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Reviews> GetAll()
        {
            return _context.Reviews.Include(x => x.Films).Include(x => x.Users);
        }

        public Reviews Get(int id)
        {
            return _context.Reviews.Find(id);
        }

        public void Create(Reviews reviews)
        {
            _context.Reviews.Add(reviews);
            _context.SaveChanges();
        }

        public void Update(Reviews reviews)
        {
            _context.Entry(reviews).State = EntityState.Modified;
        }

        public IEnumerable<Reviews> Find(Func<Reviews, Boolean> predicate)
        {
            return _context.Reviews.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Reviews reviews = _context.Reviews.Find(id);
            if (reviews != null)
                _context.Reviews.Remove(reviews);
        }
    }
}
