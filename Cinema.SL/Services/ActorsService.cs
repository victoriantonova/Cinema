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
    public class ActorsService : IActorsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActorsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ActorsVM> GetAll()
        {
            List<ActorsVM> genresVM = new List<ActorsVM>();
            IEnumerable<Actors> genres = _unitOfWork.Actors.GetAll();

            foreach (Actors f in genres)
            {
                genresVM.Add(new ActorsVM { Id = f.Id, Name = f.Name, Surname = f.Surname });
            }

            return genresVM;
        }

        public ActorsVM FindById(int genreId)
        {
            Actors f = _unitOfWork.Actors.Get(genreId);

            return new ActorsVM { Id = f.Id, Name = f.Name, Surname = f.Surname };
        }
    }
}
