using Cinema.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Interfaces
{
    public interface ISeatsBusyService
    {
        IEnumerable<SeatsBusy> getSeatsBusy();
        int getBusy(int id_seance, int id_seat);
        int getSeat(int id_busy);
        IEnumerable<SeatsBusy> getSeatsBusyIdSeance(int entered_idseance);
        bool IsSeatBusy(int entered_idseance, int entered_idseat);
        bool IsSeatPaid(int entered_idseat, int entered_idseance);
        void CreateSeatBusy(int entered_idseance, int entered_idseat);
        void UpdateSeatBusy(int entered_idseance, int entered_idseat, bool isbusy);
    }
}
