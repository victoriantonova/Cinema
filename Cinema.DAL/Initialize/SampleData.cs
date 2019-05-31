using Cinema.DAL.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.DAL.Initialize
{
    public static class SampleData
    {
        public static void Initialize(DatabaseContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (!context.Genres.Any())
            {
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Боевик"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Вестерн"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Гангстерский фильм"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Детектив"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Драма"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Исторический фильм"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Комедия"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Мелодрама"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Музыкальный фильм"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Нуар"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Политический фильм"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Приключенческий фильм"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Сказка"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Трагедия"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Трагикомедия"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Триллер"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Фантастика"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Ужасы"
                    });
                context.Genres.Add(
                    new Genres
                    {
                        Name = "Фильм катастрофа"
                    });

                context.SaveChanges();
            }

            if (!context.ApplicationUsers.Any())
            {
                ApplicationUser manager = new ApplicationUser { UserName = "moderator", Email = "moderator@gmail.com" };
                userManager.CreateAsync(manager, ".System99");

                IdentityResult roleResult = roleManager.CreateAsync(new IdentityRole("Moderator")).Result;
                if (roleResult.Succeeded)
                {
                    userManager.AddToRoleAsync(manager, "Moderator");
                }
            }

            if (!context.Films.Any())
            {
                context.Films.Add(
                    new Films
                    { Name = "Мстители: Финал",
                    Year = 2019,
                    Duration = 182,
                    Description = "Оставшиеся в живых члены команды Мстителей и их союзники должны разработать новый план, который поможет противостоять разрушительным действиям могущественного титана Таноса. После наиболее масштабной и трагической битвы в истории они не могут допустить ошибку.",
                    Img = "/img/mstiteli.jpg",
                    DateStart = Convert.ToDateTime("20-05-2019"),
                    DateEnd = Convert.ToDateTime("20-06-2019")

                    });

                context.Films.Add(
                    new Films
                    {
                        Name = "Мстители: Новое",
                        Year = 2019,
                        Duration = 168,
                        Description = "Оставшиеся в живых члены команды Мстителей и их союзники должны разработать новый план, который поможет противостоять разрушительным действиям могущественного титана Таноса. После наиболее масштабной и трагической битвы в истории они не могут допустить ошибку.",
                        Img = "/img/mstiteli.jpg",
                        DateStart = Convert.ToDateTime("20-05-2019"),
                        DateEnd = Convert.ToDateTime("20-06-2019")
                    });

                context.SaveChanges();
            }

            if (!context.Actors.Any())
            {
                context.Actors.Add(
                    new Actors
                    {
                        Name = "Роберт",
                        Surname = "Дауни"                        
                    });

                context.Actors.Add(
                new Actors
                {
                    Name = "Крис",
                    Surname = "Эванс"
                });

                context.Actors.Add(
                new Actors
                {
                    Name = "Скарлетт",
                    Surname = "Йохансен"
                });

                context.Actors.Add(
                new Actors
                {
                    Name = "Марк",
                    Surname = "Руффало"
                });
                context.SaveChanges();
            }

            if (!context.Cinemas.Any())
            {
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "3D Кино в Замке",
                        City = "Минск",
                        Address = "пр-т Победителей, 65"
                    });
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "Аврора",
                        City = "Минск",
                        Address = "ул. Притыцкого, 23"
                    });
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "Беларусь",
                        City = "Минск",
                        Address = "ул. Романовская Слобода, 28"
                    });
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "Берестье",
                        City = "Минск",
                        Address = "пр-т Газеты Правда, 25"
                    });
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "Дом Кино",
                        City = "Минск",
                        Address = "ул. Толбухина, 18"
                    });
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "Киев",
                        City = "Минск",
                        Address = "ул. Каховская, 31"
                    });
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "Мир",
                        City = "Минск",
                        Address = "ул. Козлова, 4А"
                    });
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "Москва",
                        City = "Минск",
                        Address = "пр-т Победителей, 13"
                    });
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "Октябрь",
                        City = "Минск",
                        Address = "пр-т Независимости, 73"
                    });
                context.Cinemas.Add(
                    new Cinemas
                    {
                        Name = "Центральный",
                        City = "Минск",
                        Address = "пр-т Независимости, 13"
                    });
                context.SaveChanges();
            }

            //if (!context.CinemaHalls.Any())
            //{
            //    context.CinemaHalls.Add(
            //        new CinemaHalls
            //        {
            //            IdCinema = 1,
            //            NumberHall = 1,
            //            CountRows = 9
            //        });
            //    context.CinemaHalls.Add(
            //        new CinemaHalls
            //        {
            //            IdCinema = 1,
            //            NumberHall = 2,
            //            CountRows = 11
            //        });
            //    context.SaveChanges();
            //}

            //if (!context.CinemaHallRows.Any())
            //{
            //    for (int i = 1; i < 9; i++)
            //    {
            //        context.CinemaHallRows.Add(
            //            new CinemaHallRows
            //            {
            //                IdHall = 1,
            //                NumberRow = i
            //            });
            //    }

            //    for (int i = 1; i < 11; i++)
            //    {
            //        context.CinemaHallRows.Add(
            //            new CinemaHallRows
            //            {
            //                IdHall = 2,
            //                NumberRow = i
            //            });
            //    }
            //    context.SaveChanges();
            //}

            //if (!context.CinemaHallRowsSeat.Any())
            //{
            //    for (int i = 1; i < 20; i++)
            //    {
            //        context.CinemaHallRowsSeat.Add(
            //        new CinemaHallRowsSeat
            //        {
            //            IdRow = 1,
            //            NumberSeat = i
            //        });
            //    }

            //    for (int i = 1; i < 24; i++)
            //    {
            //        context.CinemaHallRowsSeat.Add(
            //        new CinemaHallRowsSeat
            //        {
            //            IdRow = 2,
            //            NumberSeat = i
            //        });
            //    }

            //    for (int i = 1; i < 24; i++)
            //    {
            //        context.CinemaHallRowsSeat.Add(
            //        new CinemaHallRowsSeat
            //        {
            //            IdRow = 3,
            //            NumberSeat = i
            //        });
            //    }
            //    for (int i = 1; i < 24; i++)
            //    {
            //        context.CinemaHallRowsSeat.Add(
            //        new CinemaHallRowsSeat
            //        {
            //            IdRow = 4,
            //            NumberSeat = i
            //        });
            //    }
            //    for (int i = 1; i < 24; i++)
            //    {
            //        context.CinemaHallRowsSeat.Add(
            //        new CinemaHallRowsSeat
            //        {
            //            IdRow = 5,
            //            NumberSeat = i
            //        });
            //    }
            //    for (int i = 1; i < 24; i++)
            //    {
            //        context.CinemaHallRowsSeat.Add(
            //        new CinemaHallRowsSeat
            //        {
            //            IdRow = 6,
            //            NumberSeat = i
            //        });
            //    }
            //    for (int i = 1; i < 24; i++)
            //    {
            //        context.CinemaHallRowsSeat.Add(
            //        new CinemaHallRowsSeat
            //        {
            //            IdRow = 7,
            //            NumberSeat = i
            //        });
            //    }
            //    for (int i = 1; i < 24; i++)
            //    {
            //        context.CinemaHallRowsSeat.Add(
            //        new CinemaHallRowsSeat
            //        {
            //            IdRow = 8,
            //            NumberSeat = i
            //        });
            //    }
            //    for (int i = 1; i < 12; i++)
            //    {
            //        context.CinemaHallRowsSeat.Add(
            //        new CinemaHallRowsSeat
            //        {
            //            IdRow = 9,
            //            NumberSeat = i
            //        });
            //    }
            //    context.SaveChanges();
            //}

        }
    }
}
