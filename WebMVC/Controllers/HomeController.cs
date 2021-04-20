using System;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nancy.Json;
using Application.Exceptions;
using Application.Helpers;

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
        private readonly ImdbTop100Command imdbService;

        public HomeController(ILogger<HomeController> logger, IGetMoviesCommand getMovies, IGetMovieCommand getMovie, IGetPostersCommand getPosters, IGetCommentsCommand getComments, IGetProjectionsCommand getProjections, IGetActorsCommand getActors, IGetReservationsCommand getReservations, IAutoAddSeatValuesCommand autoAdd, ImdbTop100Command imdbService)
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
            this.imdbService = imdbService;
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

        public ActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
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
                return RedirectToAction("Movies", new { id });
            }
        }

        [HttpGet]
        public ActionResult Top100Imdb()
        {
            try
            {
                var response = imdbService.GetTop100();

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
