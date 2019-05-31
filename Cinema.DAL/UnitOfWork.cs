using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Cinema.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext db;

        private ApplicationUserRepository userRepository;
        private FilmsRepository filmsRepository;
        private GenresRepository genresRepository;
        private GenresOfFilmRepository genresOfFilmRepository;
        private ReviewsRepository reviewsRepository;
        private ActorsRepository actorsRepository;
        private ActorsOfFilmRepository actorsOfFilmRepository;
        private CinemasRepository cinemasRepository;
        //------------------------------------------------
        private SeancesRepository seancesRepository;
        private OrdersRepository ordersRepository;
        private SeatsBusyRepository seatsBusyRepository;


        public UnitOfWork(DbContextOptions<DatabaseContext> options)
        {
            db = new DatabaseContext(options);
        }

        IApplicationUserRepository IUnitOfWork.ApplicationUsers
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new ApplicationUserRepository(db);
                }

                return userRepository;
            }
        }

        public IRepository<Films> Films
        {
            get
            {
                if (filmsRepository == null)
                    filmsRepository = new FilmsRepository(db);
                return filmsRepository;
            }
        }

        public IRepository<Genres> Genres
        {
            get
            {
                if (genresRepository == null)
                    genresRepository = new GenresRepository(db);
                return genresRepository;
            }
        }

        public IRepository<GenresOfFilm> GenresOfFilm
        {
            get
            {
                if (genresOfFilmRepository == null)
                    genresOfFilmRepository = new GenresOfFilmRepository(db);
                return genresOfFilmRepository;
            }
        }

        public IRepository<Reviews> Reviews
        {
            get
            {
                if (reviewsRepository == null)
                    reviewsRepository = new ReviewsRepository(db);
                return reviewsRepository;
            }
        }

        public IRepository<Actors> Actors
        {
            get
            {
                if (actorsRepository == null)
                    actorsRepository = new ActorsRepository(db);
                return actorsRepository;
            }
        }

        public IRepository<ActorsOfFilm> ActorsOfFilm
        {
            get
            {
                if (actorsOfFilmRepository == null)
                    actorsOfFilmRepository = new ActorsOfFilmRepository(db);
                return actorsOfFilmRepository;
            }
        }

        public IRepository<Cinemas> Cinemas
        {
            get
            {
                if (cinemasRepository == null)
                    cinemasRepository = new CinemasRepository(db);
                return cinemasRepository;
            }
        }

        //--------------------------------------------
        public IRepository<Seances> Seances
        {
            get
            {
                if (seancesRepository == null)
                    seancesRepository = new SeancesRepository(db);
                return seancesRepository;
            }
        }

        public IRepository<SeatsBusy> SeatsBusy
        {
            get
            {
                if (seatsBusyRepository == null)
                    seatsBusyRepository = new SeatsBusyRepository(db);
                return seatsBusyRepository;
            }
        }

        public IRepository<Orders> Orders
        {
            get
            {
                if (ordersRepository == null)
                    ordersRepository = new OrdersRepository(db);
                return ordersRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
