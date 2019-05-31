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
    public class GenresOfFilmService : IGenresOfFilmService
    {
       private readonly IUnitOfWork _unitOfWork;
       private readonly IMapper _mapper;

        public GenresOfFilmService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<GenresOfFilmVM> GetAll()
        {
            List<GenresOfFilmVM> filmsVM = new List<GenresOfFilmVM>();
            IEnumerable<GenresOfFilm> films = _unitOfWork.GenresOfFilm.GetAll();

            MapperConfiguration filmConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Films, FilmsVM>();
            });
            IMapper filmMap = filmConfig.CreateMapper();

            MapperConfiguration genresConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genres, GenresVM>();
            });
            IMapper genresMap = genresConfig.CreateMapper();

            foreach (GenresOfFilm f in films)
            {
                FilmsVM filmVM = filmMap.Map<Films, FilmsVM>(f.Films);
                GenresVM genreVM = genresMap.Map<Genres, GenresVM>(f.Genres);


                filmsVM.Add(new GenresOfFilmVM { Id = f.Id, IdFilm = f.IdFilm, IdGenre = f.IdGenre, Films = filmVM, Genres = genreVM });
            }

            return filmsVM;
        }

        public GenresOfFilmVM FindById(int gfId)
        {
            GenresOfFilm genresOfFilm = _unitOfWork.GenresOfFilm.Get(gfId);

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genres, GenresVM>();
            });
            IMapper map = config.CreateMapper();
            var genres = map.Map<Genres, GenresVM>(genresOfFilm.Genres);

            MapperConfiguration userConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Films, FilmsVM>();
            });
            IMapper userMap = config.CreateMapper();
            var films = map.Map<Films, FilmsVM>(genresOfFilm.Films);

            return new GenresOfFilmVM { Id = genresOfFilm.Id, IdFilm = genresOfFilm.IdFilm, IdGenre = genresOfFilm.IdGenre, Films = films, Genres = genres };
        }

        public List<GenresOfFilmVM> FindGenresByIdFilm(int gfId)
        {
            IEnumerable<GenresOfFilm> films = _unitOfWork.GenresOfFilm.GetAll();

            MapperConfiguration filmConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GenresOfFilm, GenresOfFilmVM>();
            });
            IMapper filmMap = filmConfig.CreateMapper();

            ICollection<GenresOfFilmVM> images = filmMap.Map<IEnumerable<GenresOfFilm>, ICollection<GenresOfFilmVM>>(films);


            //MapperConfiguration filmConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Films, FilmsVM>();
            //});
            //IMapper filmMap = filmConfig.CreateMapper();

            //MapperConfiguration genresConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Genres, GenresVM>();
            //});
            //IMapper genresMap = genresConfig.CreateMapper();

            List<GenresOfFilmVM> result = new List<GenresOfFilmVM>();
            result.AddRange(images);


            return result.FindAll(x => x.IdFilm == gfId);
        }

    }
}
