using AutoMapper;
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
    public class CinemasService : ICinemasService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISeanceService _seanceService;
        public CinemasService(IUnitOfWork unitOfWork, IMapper mapper, ISeanceService seanceService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _seanceService = seanceService;
        }

        public List<CinemasVM> GetAll()
        {
            List<CinemasVM> cVM = new List<CinemasVM>();
            IEnumerable<Cinemas> cinemas = _unitOfWork.Cinemas.GetAll();

            foreach (Cinemas f in cinemas)
            {
                cVM.Add(new CinemasVM { Id = f.Id, Name = f.Name, City = f.City, Address = f.Address, CountSeats = f.CountSeats });
            }

            return cVM;
        }

        public CinemasVM FindById(int cId)
        {
            Cinemas f = _unitOfWork.Cinemas.Get(cId);

            return new CinemasVM { Id = f.Id, Name = f.Name, City = f.City, Address = f.Address };
        }
        public IEnumerable<Cinemas> GetAllFilms()
        {
            return _unitOfWork.Cinemas.GetAll();
        }
        public Cinemas GetFilmById(int id)
        {
            return _unitOfWork.Cinemas.Get(id);
        }
        public void AddCinema(Cinemas cinema)
        {
            Cinemas cinemas = new Cinemas();
            cinemas.Name = cinema.Name;
            cinemas.City = cinema.City;
            cinemas.Address = cinema.Address;
            cinemas.CountSeats = cinema.CountSeats;
            _unitOfWork.Cinemas.Create(cinemas);
        }
        public Cinemas getCinemaofSeance(int idcinema)
        {
            return _unitOfWork.Cinemas.GetAll().Where(x=>x.Id.Equals(idcinema)).FirstOrDefault();
        }
        public IEnumerable<Cinemas> getCinemaInfoOfSeanceId(int idfilm)
        {
            IEnumerable<Seances> seanceinfo = _seanceService.getSeanceInfoOfIdFilm(idfilm);
            List<Cinemas> cin = new List<Cinemas>();
            
            foreach (Seances seance in seanceinfo)
            {
               var data =  _unitOfWork.Cinemas.GetAll().Where(x => x.Id.Equals(seance.IdCinema)).FirstOrDefault();
                cin.Add(data);
            }
            return cin;
        }

    }
}
