using AutoMapper;
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
    public class ReviewsControllerTest
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private ReviewsAPIController _controller;
        //private IReviewsService _reviewsService;
        //private IMapper _mapper;



        //public ReviewsControllerTest()
        //{
        //    _reviewsService = new ReviewsService(_unitOfWork, _mapper);
        //    _controller = new ReviewsAPIController(_reviewsService);
        //}

        //#region Get Methods
        //[Fact]
        //public void Get_ReturnsNoResult()
        //{
        //    Act
        //    ActionResult<IEnumerable<ReviewsVM>> result = _controller.Get();

        //    Assert
        //    Assert.Empty(result.Value);
        //}

        //[Fact]
        //public void Get_ReturnsAllItems()
        //{
        //    Act
        //    ActionResult<IEnumerable<ReviewsVM>> result = _controller.Get();

        //    Assert
        //    List<ReviewsVM> items = Assert.IsType<List<ReviewsVM>>(result);
        //    Assert.Equal(2, items.Count);
        //}
        //#endregion
    }
}
