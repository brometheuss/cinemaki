using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.ICommands.CommentCommands;
using Application.ICommands.MovieCommands;
using Application.ICommands.PosterCommands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetMoviesCommand getMovies;
        private readonly IGetMovieCommand getMovie;
        private readonly IGetPostersCommand getPosters;
        private readonly IGetCommentsCommand getComments;

        public HomeController(ILogger<HomeController> logger, IGetMoviesCommand getMovies, IGetMovieCommand getMovie, IGetPostersCommand getPosters, IGetCommentsCommand getComments)
        {
            _logger = logger;
            this.getMovies = getMovies;
            this.getMovie = getMovie;
            this.getPosters = getPosters;
            this.getComments = getComments;
        }

        public ActionResult Index()
        {
            try
            {
                ViewBag.Movies = getMovies.Execute(new Application.Queries.MovieQuery()).Data;
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
                ViewBag.Posters = getPosters.Execute(new Application.Queries.PosterQuery { MovieId = id }).Data;
                ViewBag.Comments = getComments.Execute(new Application.Queries.CommentQuery { MovieId = id }).Data;
                return View(getMovie.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

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
