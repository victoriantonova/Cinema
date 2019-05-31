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
    public class FilmsService : IFilmsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FilmsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<FilmsVM> GetAll()
        {
            List<FilmsVM> filmsVM = new List<FilmsVM>();
            IEnumerable<Films> films = _unitOfWork.Films.GetAll();

            foreach (Films f in films)
            {
                filmsVM.Add(new FilmsVM { Id = f.Id, Name = f.Name, Description = f.Description, Duration = f.Duration, Year = f.Year, Img = f.Img, DateStart = f.DateStart, DateEnd = f.DateEnd });
            }

            return filmsVM;
        }

        public FilmsVM FindById(int filmId)
        {
            Films f = _unitOfWork.Films.Get(filmId);

            return new FilmsVM { Id = f.Id, Name = f.Name, Description = f.Description, Duration = f.Duration, Year = f.Year, Img = f.Img, DateStart = f.DateStart, DateEnd = f.DateEnd };
        }
        public Films getFilmofSeance(int idfilm)
        {
            return _unitOfWork.Films.GetAll().Where(x => x.Id.Equals(idfilm)).FirstOrDefault();
        }
    }
}
