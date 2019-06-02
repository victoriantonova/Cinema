using Cinema.Controllers;
using Cinema.DAL.Interfaces;
using Cinema.Models;
using Cinema.SL.Interfaces;
using Cinema.SL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class SeancesControllerTest
    {
        private readonly IUnitOfWork _unitOfWork;
        private SeancesController _controller;
        private ICinemasService _cinemasService;
        private IFilmsService _filmsService;
        private ISeanceService _seanceService;
        private ISeatsBusyService _seatsBusyService;


        //public SeancesControllerTest()
        //{
        //    _seanceService = new SeanceService(_unitOfWork, _filmsService, _seatsBusyService);
        //    _controller = new SeancesController(_seanceService);
        //}


        //#region Get Methods
        //[Fact]
        //public void Get_ReturnsNoResult()
        //{
        //    // Act
        //    IEnumerable<SeanceInfo> result = _controller.GetSeances();

        //    // Assert
        //    Assert.Empty(result);
        //}

        //[Fact]
        //public void Get_ReturnsAllItems()
        //{
        //    // Act
        //    IEnumerable<SeanceInfo> result = _controller.GetSeances();

        //    // Assert
        //    List<SeanceInfo> items = Assert.IsType<List<SeanceInfo>>(result);
        //    Assert.Equal(2, items.Count);
        //}
        //#endregion

    }
}
