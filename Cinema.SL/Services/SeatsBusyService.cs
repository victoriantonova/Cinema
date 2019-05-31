using Cinema.DAL;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Cinema.Models;
using Cinema.SL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.SL.Services
{
    public class SeatBusyService : ISeatsBusyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeatBusyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SeatsBusy> getSeatsBusy()
        {
            return _unitOfWork.SeatsBusy.GetAll();
        }

        public int getBusy(int id_seance, int id_seat)
        {
            //return _unitOfWork.SeatsBusy.getId(id_seance, id_seat).Result.id_busy;
            var result = _unitOfWork.SeatsBusy.GetAll().Where(x => x.IdSeance.Equals(id_seance) && x.IdSeatbusy.Equals(id_seat)).FirstOrDefault();
            return result.Id;
        }
        public int getSeat(int id_busy)
        {
            //return _unitOfWork.SeatsBusy.GetIdBusy(id_busy).Result.Id_Seatbusy;
            var result = _unitOfWork.SeatsBusy.GetAll().Where(x=>x.Id.Equals(id_busy)).FirstOrDefault();
            return result.IdSeatbusy;
        }
        public IEnumerable<SeatsBusy> getSeatsBusyIdSeance(int entered_idseance)
        {
            //return _unitOfWork.SeatsBusy.GetBySeanceId(entered_idseance);
            return _unitOfWork.SeatsBusy.GetAll().Where(x => x.IdSeance.Equals(entered_idseance));
        }

        public bool IsSeatBusy(int entered_idseance, int entered_idseat)
        {
            var data = _unitOfWork.SeatsBusy.GetAll().Where(s => s.IdSeatbusy.Equals(entered_idseat)).Where(ss => ss.IdSeance.Equals(entered_idseance)).FirstOrDefault();
            if (data.Isbusy == true)
            {
                return true;
            }
            else return false;
        }
        public bool IsSeatPaid(int entered_idseat, int entered_idseance)
        {
            //var datas = unitOfWork.SeatsBusy.GetAll().Where(id => id.Id_Seatbusy.Equals(entered_idseat)).Where(id => id.Id_Seance.Equals(entered_idseance)).FirstOrDefault();
            var dataorder = _unitOfWork.Orders.GetAll().Where(id => id.IdSeance.Equals(entered_idseance)).Where(id => id.IdSeat.Equals(entered_idseat)).FirstOrDefault();
            if (dataorder.Ispaid == true)
            {
                return true;
            }
            else return false;
        }
        public void CreateSeatBusy(int entered_idseance, int entered_idseat)
        {
            SeatsBusy seatsbusy = new SeatsBusy();
            seatsbusy.IdSeance = entered_idseance;
            seatsbusy.IdSeatbusy = entered_idseat;
            seatsbusy.Isbusy = false;
            _unitOfWork.SeatsBusy.Create(seatsbusy);
            _unitOfWork.Save();
        }
        public void UpdateSeatBusy(int entered_idseance, int entered_idseat, bool isbusy)
        {
            //var datas = _unitOfWork.SeatsBusy.GetSS(entered_idseance, entered_idseat);
            var datas = _unitOfWork.SeatsBusy.GetAll().Where(x => x.IdSeance.Equals(entered_idseance) && x.IdSeatbusy.Equals(entered_idseat)).FirstOrDefault();
            datas.Isbusy = isbusy;
            _unitOfWork.SeatsBusy.Update(datas);
        }

    }
}
