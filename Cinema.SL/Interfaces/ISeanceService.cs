using Cinema.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.SL.Interfaces
{
    public interface ISeanceService
    {
        IEnumerable<Seances> getSeancesIds();
        Seances getInfofSeance(int id_seance);
        Task<Seances> getSeanceId(int entered_idseance);
        Task<Seances> getBusyId(int entered_idseance);
        Seances getDateofSeance(int entered_idseance);
        void UpdateSeance(int id, Seances seance);
        void deleteSeance(int id);
        int CountSeats(int entered_idseance);
        void SeatDecrement(int entered_idseance);
        void SeatIncrement(int entered_idseance);
        void CreateSeance(Seances seances);
        Seances getInfoAboutSeanceandFilm(int id_busy);
        bool OverdueSeance(int entered_idseance);
        IEnumerable<Seances> getSeanceInfoOfIdFilm(int idfilm);
        IEnumerable<Seances> getSeanceofOrder(int idorderseance);
    }
}
