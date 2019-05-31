using AutoMapper;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Cinema.Models;
using Cinema.SL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Services
{
    public class GenresService : IGenresService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenresService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<GenresVM> GetAll()
        {
            List<GenresVM> genresVM = new List<GenresVM>();
            IEnumerable<Genres> genres = _unitOfWork.Genres.GetAll();

            foreach (Genres f in genres)
            {
                genresVM.Add(new GenresVM { Id = f.Id, Name = f.Name });
            }

            return genresVM;
        }

        public GenresVM FindById(int genreId)
        {
            Genres f = _unitOfWork.Genres.Get(genreId);

            return new GenresVM { Id = f.Id, Name = f.Name };
        }

        
    }
}
