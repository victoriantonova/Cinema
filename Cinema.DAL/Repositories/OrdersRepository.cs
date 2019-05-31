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
    public class OrdersRepository : IRepository<Orders>
    {
        private readonly DatabaseContext _context;

        public OrdersRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Orders> GetAll()
        {
            return _context.Orders;
        }
        //public IEnumerable<Orders> GetAll(string u)
        //{
        //    return _context.Orders.Where(uu => uu.IdUser.Equals(u));
        //}       

        public Orders Get(int id)
        {
            return _context.Orders.Find(id);
        }

        //public IEnumerable<Orders> GetSeance(int entered_idseance)
        //{
        //    IEnumerable<Orders> idorders = _context.Orders.Where(ids => ids.IdSeance.Equals(entered_idseance));
        //    return idorders;
        //}

        public void Create(Orders seance)
        {
            //_context.Entry(seance).State = EntityState.Added;
            //return _context.SaveChangesAsync();
            _context.Orders.Add(seance);
            _context.SaveChanges();
        }

        public void Update(Orders seance)
        {
            _context.Entry(seance).Property(c => c.Ispaid).IsModified = true;
            _context.SaveChanges();
            //return _context.SaveChanges();
        }

        public IEnumerable<Orders> Find(Func<Orders, Boolean> predicate)
        {
            return _context.Orders.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Orders seances = _context.Orders.Where(i => i.Id.Equals(id)).FirstOrDefault();
            if (seances == null)
            {
                throw new Exception("Нечего удалять");
            }
            else
            {
                _context.Orders.Remove(seances);
                _context.SaveChanges();
            }

        }
    }
}
