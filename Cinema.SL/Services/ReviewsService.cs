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
    public class ReviewsService : IReviewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ReviewsVM> GetAll()
        {
            List<ReviewsVM> reviewsVM = new List<ReviewsVM>();
            IEnumerable<Reviews> reviews = _unitOfWork.Reviews.GetAll();

            MapperConfiguration filmConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Films, FilmsVM>();
            });
            IMapper filmMap = filmConfig.CreateMapper();

            MapperConfiguration userConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, ApplicationUserVM>();
            });
            IMapper userMap = userConfig.CreateMapper();

            foreach (Reviews f in reviews) //
            {
                FilmsVM filmVM = filmMap.Map<Films, FilmsVM>(f.Films);
                ApplicationUserVM genreVM = userMap.Map<ApplicationUser, ApplicationUserVM>(f.Users);

                reviewsVM.Add(new ReviewsVM { Id = f.Id, IdFilm = f.IdFilm, IdAuthor = f.IdAuthor, Date = f.Date, Feedback = f.Feedback, Films = filmVM, Users = genreVM });
            }

            return reviewsVM;
        }

        //public GenresOfFilmVM FindById(int gfId)
        //{
        //    GenresOfFilm genresOfFilm = _unitOfWork.GenresOfFilm.Get(gfId);

        //    MapperConfiguration config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Genres, GenresVM>();
        //    });
        //    IMapper map = config.CreateMapper();
        //    var genres = map.Map<Genres, GenresVM>(genresOfFilm.Genres);

        //    MapperConfiguration userConfig = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Films, FilmsVM>();
        //    });
        //    IMapper userMap = config.CreateMapper();
        //    var films = map.Map<Films, FilmsVM>(genresOfFilm.Films);

        //    return new GenresOfFilmVM { Id = genresOfFilm.Id, IdFilm = genresOfFilm.IdFilm, IdGenre = genresOfFilm.IdGenre, Films = films, Genres = genres };
        //}

        public List<ReviewsVM> GetReviewsByIdFilm(int gfId)
        {
            IEnumerable<Reviews> films = _unitOfWork.Reviews.GetAll();

            MapperConfiguration filmConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reviews, ReviewsVM>();
            });
            IMapper filmMap = filmConfig.CreateMapper();

            ICollection<ReviewsVM> images = filmMap.Map<IEnumerable<Reviews>, ICollection<ReviewsVM>>(films);

            List<ReviewsVM> result = new List<ReviewsVM>();
            result.AddRange(images);

            return result.FindAll(x => x.IdFilm == gfId);
        }

        public void Create(ReviewsVM review)
        {
                _unitOfWork.Reviews.Create(new Reviews { IdFilm = review.IdFilm, IdAuthor = review.IdAuthor, Feedback = review.Feedback, Date = review.Date });
                _unitOfWork.Save();           
         
        }
    }
}
