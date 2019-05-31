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
    public class SeatsBusyRepository : IRepository<SeatsBusy>
    {
        private DatabaseContext db;

        public SeatsBusyRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public IEnumerable<SeatsBusy> GetAll()
        {
            return db.SeatsBusy;
        }

        public Task<SeatsBusy> GetIdBusy(int idbusy)
        {
            return db.SeatsBusy.Where(i => i.Id.Equals(idbusy)).FirstOrDefaultAsync();
        }

        public IEnumerable<SeatsBusy> GetBySeanceId(int idseance)
        {
            return db.SeatsBusy.Where(id => id.IdSeance.Equals(idseance));
        }

        public Task<SeatsBusy> getId(int id_seance, int id_seat)
        {
            return db.SeatsBusy.Where(i => i.IdSeance.Equals(id_seance)).Where(ii => ii.IdSeatbusy.Equals(id_seat)).FirstOrDefaultAsync();
        }

        public SeatsBusy Get(int id)
        {
            return db.SeatsBusy.Find(id);
        }

        public SeatsBusy GetSS(int id_seance, int id_seat)
        {
            SeatsBusy sb = db.SeatsBusy.Where(ids => ids.IdSeance.Equals(id_seance)).Where(idss => idss.IdSeatbusy.Equals(id_seat)).FirstOrDefault();
            return sb;
        }

        public IEnumerable<SeatsBusy> GetSeatsBusy(int entered_idseance)
        {
            var datas = db.SeatsBusy.Include(id => id.IdSeatbusy).Where(ids => ids.IdSeance.Equals(entered_idseance));
            return datas;
        }

        public void Create(SeatsBusy seat_busy)
        {
            db.Entry(seat_busy).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(SeatsBusy seat_busy)
        {
            db.Entry(seat_busy).Property(c => c.Isbusy).IsModified = true;
            db.SaveChanges();
            //return db.SaveChanges();
        }

        public IEnumerable<SeatsBusy> Find(Func<SeatsBusy, Boolean> predicate)
        {
            return db.SeatsBusy.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            SeatsBusy seat_busy = db.SeatsBusy.Where(i => i.Id.Equals(id)).FirstOrDefault();
            if (seat_busy == null)
            {
                throw new Exception("Нечего удалять");
            }
            else
            {
                db.SeatsBusy.Remove(seat_busy);
                db.SaveChangesAsync();
            }
        }
    }
}
