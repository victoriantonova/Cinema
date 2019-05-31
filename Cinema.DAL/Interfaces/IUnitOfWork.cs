using Cinema.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Interfaces
{
    public interface IUnitOfWork 
        //: IDisposable
    {
        //IRepository<Category> Categories { get; }
        //IRepository<Subcategory> Subcategories { get; }
        //IRepository<Region> Regions { get; }
        //IRepository<City> Cities { get; }
        //IRepository<Post> Posts { get; }
        //IRepository<ImagesGallery> ImagesGallery { get; }
        //IRepository<Order> Orders { get; }
        //IRepository<Operation> Operations { get; }
        IApplicationUserRepository ApplicationUsers { get; }
        IRepository<Films> Films { get; }
        IRepository<Genres> Genres { get; }
        IRepository<GenresOfFilm> GenresOfFilm { get; }
        IRepository<Reviews> Reviews { get; }
        IRepository<Actors> Actors { get; }
        IRepository<ActorsOfFilm> ActorsOfFilm { get; }
        IRepository<Cinemas> Cinemas { get; }
        //----------------------------------------------------
        IRepository<Seances> Seances { get; }
        IRepository<Orders> Orders { get; }
        IRepository<SeatsBusy> SeatsBusy { get; }


        void Save();
    }
}
