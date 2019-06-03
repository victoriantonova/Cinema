using AutoMapper;
using Cinema.Controllers;
using Cinema.DAL;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Model;
using Cinema.Models;
using Cinema.SL.Interfaces;
using Cinema.SL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class FilmsAPIControllerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private IFilmsService _service;
        private FilmsAPIController _controller;
        private IMapper _mapper;

        public FilmsAPIControllerTest()
        {
            var option = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "DefaultConnection")
                .Options;

            _unitOfWork = new UnitOfWork(option);

            #region
            _unitOfWork.Films.Create(new Films
            {
                Name = "Test",
                Year = 2019,
                Duration = 182,
                Description = "Оставшиеся в живых члены команды Мстителей и их союзники должны разработать новый план, который поможет противостоять разрушительным действиям могущественного титана Таноса. После наиболее масштабной и трагической битвы в истории они не могут допустить ошибку.",
                Img = "/img/mstiteli.jpg",
                DateStart = Convert.ToDateTime("20-05-2019"),
                DateEnd = Convert.ToDateTime("20-06-2019")
            });
            _unitOfWork.Save();

            _unitOfWork.ApplicationUsers.Create();
            var user = _unitOfWork.ApplicationUsers.GetByEmail("leshencko.nastia2013@gmail.com");

            #endregion

            _service = new FilmsService(_unitOfWork, _mapper);
            _controller = new FilmsAPIController(_service);
        }

        #region Get Methods
        [Fact]
        public void Get_ReturnsResult()
        {
            // Act
            ActionResult<IEnumerable<FilmsVM>> result = _controller.Get();

            // Assert
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public void GetById_ReturnsOkResult()
        {
            // Act
            ActionResult<FilmsVM> okResult = _controller.Get(1);

            // Assert
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void GetById_NotEqual()
        {
            // Act
            ActionResult<FilmsVM> oneFoundResult = _controller.Get(1);
            ActionResult<FilmsVM> twoFoundResult = _controller.Get(2);

            // Assert
            Assert.NotEqual(oneFoundResult, twoFoundResult);
        }

        #endregion
    }
}
