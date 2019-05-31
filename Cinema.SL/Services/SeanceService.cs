﻿using Cinema.DAL;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Cinema.Models;
using Cinema.SL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.SL.Services
{
    public class SeanceService : ISeanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeatsBusyService _seatsBusyService;
        private readonly IFilmsService _filmService;
        public SeanceService(IUnitOfWork unitOfWork, IFilmsService filmService, ISeatsBusyService seatsBusyService)
        {
            _unitOfWork = unitOfWork;
            _filmService = filmService;
            _seatsBusyService = seatsBusyService;
        }


        public IEnumerable<Seances> getSeancesIds()
        {
            //return _unitOfWork.Seances.GetAllId();
            return _unitOfWork.Seances.GetAll();

        }

        //public IEnumerable<Seances> getSeances()
        //{
        //    return _unitOfWork.Seances.GetAllA();
        //}

        public Seances getInfofSeance(int id_seance)
        {
            //return _unitOfWork.Seances.GetAllA().Where(i => i.Id_Seance.Equals(id_seance)).FirstOrDefault();
            return _unitOfWork.Seances.GetAll().Where(i => i.Id.Equals(id_seance)).FirstOrDefault();
        }

        public Task<Seances> getSeanceId(int entered_idseance)
        {
            return Task.Run(() => _unitOfWork.Seances.Get(entered_idseance));
            //return unitOfWork.Seances.GetAll().Where(f => f.Id_Seance.Equals(entered_idseance));
        }
        public Task<Seances> getBusyId(int entered_idseance)
        {
            return Task.Run(() => _unitOfWork.Seances.Get(entered_idseance));
            //return unitOfWork.Seances.GetAll().Where(f => f.Id_Seance.Equals(entered_idseance));
        }

        public Seances getDateofSeance(int entered_idseance)
        {
            return getDateofSeance(entered_idseance);
        }
        public void UpdateSeance(int id, Seances seance)
        {
            if (seance == null)
            {
                throw new ArgumentNullException();
            }
            var datas = _unitOfWork.Seances.GetAll().Where(i => i.Id.Equals(id)).FirstOrDefault();
            datas.Price = seance.Price;
            _unitOfWork.Seances.Update(datas);
        }

        public void deleteSeance(int id)
        {
            _unitOfWork.Seances.Delete(id);
            //var idseance = unitOfWork.Orders.GetSeance(id);
            //if (unitOfWork.Orders.GetSeance(id) != null)
            //{
            //    foreach (var idseance in unitOfWork.Orders.GetSeance(id))
            //    {
            //        unitOfWork.Orders.Delete(idseance.id_seance);
            //    }

            //    foreach (var idseat in unitOfWork.SeatsBusy.GetSeatsBusy(id))
            //    {
            //        unitOfWork.SeatsBusy.Delete(idseat);
            //    }
            //}
        }

        public int CountSeats(int entered_idseance)
        {
            var datas = _unitOfWork.Seances.GetAll().Where(id => id.Id.Equals(entered_idseance)).FirstOrDefault();
            return datas.Count_Seats;
        }

        public void SeatDecrement(int entered_idseance)
        {
            var datas = _unitOfWork.Seances.Get(entered_idseance);
            datas.Count_Seats = datas.Count_Seats - 1;
            _unitOfWork.Seances.Update(datas);

            //var result = _unitOfWork.Seances.Get(entered_idseance);
            //return result.Count_Seats;
        }

        public void CreateSeance(Seances seances)
        {
            //DateTime date = new DateTime();
            DateTime date = DateTime.Now;
            //var cinemaRes = _unitOfWork.Cinemas.GetCount(seances.IdCinema);
            var seats = _unitOfWork.Cinemas.Get(seances.IdCinema).CountSeats;
            if (seats != 0)
            {

                //TimeSpan hour = TimeSpan.FromTicks();
                Seances seance = new Seances();
                var datas = _unitOfWork.Films.Get(seances.IdFilm);
                if (seances.DateSeance.Year >= datas.DateStart.Year && seances.DateSeance.Year <= datas.DateEnd.Year)
                {
                    if (seances.DateSeance.Month > datas.DateStart.Month && seances.DateSeance.Month < datas.DateEnd.Month)
                    {
                        if (seances.DateSeance.Year >= date.Year)
                        {
                            if (seances.DateSeance.Month >= date.Month)
                            {
                                if (seances.DateSeance.Day >= date.Day)
                                {
                                    {
                                        seance.IdCinema = seances.IdCinema;
                                        seance.IdFilm = seances.IdFilm;
                                        seance.DateSeance = seances.DateSeance;
                                        seance.TimeSeance = seances.TimeSeance;
                                        seance.Price = seances.Price;
                                        seance.Count_Seats = seats;
                                        seance.AllSeats = seats;
                                        _unitOfWork.Seances.Create(seance);

                                        var thisseance = _unitOfWork.Seances.GetAll().Where(x => x.IdCinema.Equals(seances.IdCinema) && x.IdFilm.Equals(seances.IdFilm) && x.DateSeance.Equals(seances.DateSeance) && x.TimeSeance.Equals(seances.TimeSeance)).FirstOrDefault();
                                        if (thisseance.Id != 0)
                                        {
                                            var COUNTSEATS = _unitOfWork.Seances.Get(thisseance.Id).AllSeats;

                                            int i = 1;
                                            if (thisseance.Id != 0)
                                            {
                                                for (i = 1; i <= COUNTSEATS; i++)
                                                {

                                                    _seatsBusyService.CreateSeatBusy(thisseance.Id, i);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else throw new Exception("sdsgh");
                    }

                    else if (seances.DateSeance.Month == datas.DateStart.Month)
                    {
                        if (seances.DateSeance.Day >= datas.DateStart.Day)
                        {
                            if (seances.DateSeance.Year >= date.Year)
                            {
                                if (seances.DateSeance.Month >= date.Month)
                                {
                                    if (seances.DateSeance.Day >= date.Day)
                                    {
                                        seance.IdCinema = seances.IdCinema;
                                        seance.IdFilm = seances.IdFilm;
                                        seance.DateSeance = seances.DateSeance;
                                        seance.TimeSeance = seances.TimeSeance;
                                        seance.Price = seances.Price;
                                        seance.Count_Seats = seats;
                                        seance.AllSeats = seats;
                                        _unitOfWork.Seances.Create(seance);

                                        var thisseance = _unitOfWork.Seances.GetAll().Where(x => x.IdCinema.Equals(seances.IdCinema) && x.IdFilm.Equals(seances.IdFilm) && x.DateSeance.Equals(seances.DateSeance) && x.TimeSeance.Equals(seances.TimeSeance)).FirstOrDefault();
                                        if (thisseance.Id != 0)
                                        {
                                            var COUNTSEATS = _unitOfWork.Seances.Get(thisseance.Id).AllSeats;

                                            int i = 1;
                                            if (thisseance.Id != 0)
                                            {
                                                for (i = 1; i <= COUNTSEATS; i++)
                                                {
                                                    _seatsBusyService.CreateSeatBusy(thisseance.Id, i);
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else throw new Exception("sdsgh");
                }
            }
        }




        //public Seances getInfoAboutSeanceandFilm(int id_busy)
        public Seances getInfoAboutSeanceandFilm(int id)
        {
            //var seance = _unitOfWork.SeatsBusy.GetIdBusy(id_busy).Result.Id_Seance;
            ////var seance = _unitOfWork.SeatsBusy.GetAll().Where(x=>x.Id)IdBusy(id_busy).Result.Id_Seance;
            ////return db.SeatsBusy.Where(i => i.Id.Equals(idbusy)).FirstOrDefaultAsync();
            //var seance = _unitOfWork.SeatsBusy.GetAll().Where(x => x.Seances.Id.Equals())IdBusy(id_busy).Result.Id_Seance;

            var data = _unitOfWork.Seances.Get(id);
            return data;
        }
        public IEnumerable<Seances> getSeanceInfoOfIdFilm(int idfilm)
        {
            return _unitOfWork.Seances.GetAll().Where(x => x.IdFilm.Equals(idfilm));

        }

        public bool OverdueSeance(int entered_idseance)
        {
            DateTime now = DateTime.Now;
            var datas = getDateofSeance(entered_idseance);
            DateTime date = datas.DateSeance;
            TimeSpan time = datas.TimeSeance;
            if (date >= now)
            {
                if (time.Hours >= now.Hour)
                {
                    if (time.Minutes > now.Minute)
                    {
                        return false;
                    }
                    else return true;
                }
                else return true;
            }
            else return true;
        }

        public IEnumerable<Seances> getSeanceofOrder(int idorderseance)
        {
            return _unitOfWork.Seances.GetAll().Where(x => x.Id.Equals(idorderseance));
        }
    }
}