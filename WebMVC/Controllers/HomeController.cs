﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.ICommands.ActorCommands;
using Application.ICommands.CommentCommands;
using Application.ICommands.MovieCommands;
using Application.ICommands.PosterCommands;
using Application.ICommands.ProjectionCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;
using Application.Queries;
using Application.ICommands.ReservationCommands;
using Microsoft.AspNetCore.Http;
using Application.DataTransfer;
using WebMVC.Session;
using Application.ICommands.IHelperCommands;
using RestSharp;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetMoviesCommand getMovies;
        private readonly IGetMovieCommand getMovie;
        private readonly IGetPostersCommand getPosters;
        private readonly IGetCommentsCommand getComments;
        private readonly IGetProjectionsCommand getProjections;
        private readonly IGetActorsCommand getActors;
        private readonly IGetReservationsCommand getReservations;
        private readonly IAutoAddSeatValuesCommand autoAdd;
        private readonly string _top250Url = "https://imdb-api.com/en/API/Top250Movies/k_fweq5i39";

        public HomeController(ILogger<HomeController> logger, IGetMoviesCommand getMovies, IGetMovieCommand getMovie, IGetPostersCommand getPosters, IGetCommentsCommand getComments, IGetProjectionsCommand getProjections, IGetActorsCommand getActors, IGetReservationsCommand getReservations, IAutoAddSeatValuesCommand autoAdd)
        {
            _logger = logger;
            this.getMovies = getMovies;
            this.getMovie = getMovie;
            this.getPosters = getPosters;
            this.getComments = getComments;
            this.getProjections = getProjections;
            this.getActors = getActors;
            this.getReservations = getReservations;
            this.autoAdd = autoAdd;
        }

        public ActionResult Index()
        {
            try
            {
                ViewBag.Movies = getMovies.Execute(new MovieQuery()).Data;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }

        public ActionResult Movies(int id)
        {
            try
            {
                ViewBag.User = HttpContext.Session.Get<ShowUserDto>("User");
                ViewBag.Actors = getActors.Execute(new ActorQuery { MovieId = id }).Data;
                ViewBag.Projections = getProjections.Execute(new ProjectionQuery { MovieId = id, PerPage = 100 }).Data;
                ViewBag.Posters = getPosters.Execute(new PosterQuery { MovieId = id }).Data;
                ViewBag.Comments = getComments.Execute(new CommentQuery { MovieId = id }).Data;
                return View(getMovie.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Top100Imdb()
        {
            try
            {
                var request = new RestRequest(_top250Url)
                {
                    Method = Method.GET
                };

                var client = new RestClient();
                var response = client.Execute<ImdbTop100>(request);

                ViewBag.Movies = response.Data;
                return View();
            }
            catch(Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        //public IActionResult AddSeatValues()
        //{
        //    try
        //    {
        //        int i = 999;
        //        autoAdd.Execute(i);
        //    }
        //    catch (Exception e)
        //    {
        //        TempData["error"] = e.Message;
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
