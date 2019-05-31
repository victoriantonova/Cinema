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
    public class ActorsOfFilmService : IActorsOfFilmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActorsOfFilmService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ActorsOfFilmVM> GetAll()
        {
            List<ActorsOfFilmVM> filmsVM = new List<ActorsOfFilmVM>();
            IEnumerable<ActorsOfFilm> films = _unitOfWork.ActorsOfFilm.GetAll();

            MapperConfiguration filmConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Films, FilmsVM>();
            });
            IMapper filmMap = filmConfig.CreateMapper();

            MapperConfiguration actorsConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Actors, ActorsVM>();
            });
            IMapper actorsMap = actorsConfig.CreateMapper();

            foreach (ActorsOfFilm f in films)
            {
                FilmsVM filmVM = filmMap.Map<Films, FilmsVM>(f.Films);
                ActorsVM actorVM = actorsMap.Map<Actors, ActorsVM>(f.Actors);


                filmsVM.Add(new ActorsOfFilmVM { Id = f.Id, IdFilm = f.IdFilm, IdActor = f.IdActor, Films = filmVM, Actors = actorVM });
            }

            return filmsVM;
        }

        public ActorsOfFilmVM FindById(int gfId)
        {
            ActorsOfFilm genresOfFilm = _unitOfWork.ActorsOfFilm.Get(gfId);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Actors, ActorsVM>();
            });
            IMapper map = config.CreateMapper();
            var genres = map.Map<Actors, ActorsVM>(genresOfFilm.Actors);

            MapperConfiguration userConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Films, FilmsVM>();
            });
            IMapper userMap = config.CreateMapper();
            var films = map.Map<Films, FilmsVM>(genresOfFilm.Films);

            return new ActorsOfFilmVM { Id = genresOfFilm.Id, IdFilm = genresOfFilm.IdFilm, IdActor = genresOfFilm.IdActor, Films = films, Actors = genres };
        }

        public List<ActorsOfFilmVM> FindActorsByIdFilm(int gfId)
        {
            IEnumerable<ActorsOfFilm> films = _unitOfWork.ActorsOfFilm.GetAll();

            MapperConfiguration filmConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ActorsOfFilm, ActorsOfFilmVM>();
            });
            IMapper filmMap = filmConfig.CreateMapper();

            ICollection<ActorsOfFilmVM> images = filmMap.Map<IEnumerable<ActorsOfFilm>, ICollection<ActorsOfFilmVM>>(films);

            List<ActorsOfFilmVM> result = new List<ActorsOfFilmVM>();
            result.AddRange(images);

            return result.FindAll(x => x.IdFilm == gfId);
        }
    }
}
