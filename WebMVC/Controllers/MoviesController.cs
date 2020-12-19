using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ActorCommands;
using Application.ICommands.CountryCommands;
using Application.ICommands.GenreCommands;
using Application.ICommands.LanguageCommands;
using Application.ICommands.MovieCommands;
using Application.ICommands.ProductionCommands;
using Application.ICommands.RatedCommands;
using Application.ICommands.WriterCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IGetMoviesCommand getMovies;
        private readonly IGetMovieCommand getMovie;
        private readonly IAddMovieCommand addMovie;
        private readonly IEditMovieCommand editMovie;
        private readonly IDeleteMovieCommand deleteMovie;
        private readonly IGetGenresCommand getGenres;
        private readonly IGetActorsCommand getActors;
        private readonly IGetLanguagesCommand getLanguages;
        private readonly IGetWritersCommand getWriters;
        private readonly IGetProductionsCommand getProductions;
        private readonly IGetCountriesCommand getCountries;
        private readonly IGetRatedsCommand getRateds;

        public MoviesController(IGetMoviesCommand getMovies, IGetMovieCommand getMovie, IAddMovieCommand addMovie, IEditMovieCommand editMovie, IDeleteMovieCommand deleteMovie, IGetGenresCommand getGenres, IGetActorsCommand getActors, IGetLanguagesCommand getLanguages, IGetWritersCommand getWriters, IGetProductionsCommand getProductions, IGetCountriesCommand getCountries, IGetRatedsCommand getRateds)
        {
            this.getMovies = getMovies;
            this.getMovie = getMovie;
            this.addMovie = addMovie;
            this.editMovie = editMovie;
            this.deleteMovie = deleteMovie;
            this.getGenres = getGenres;
            this.getActors = getActors;
            this.getLanguages = getLanguages;
            this.getWriters = getWriters;
            this.getProductions = getProductions;
            this.getCountries = getCountries;
            this.getRateds = getRateds;
        }

        // GET: Movies
        public ActionResult Index([FromQuery] MovieQuery query)
        {
            try
            {
                return View(getMovies.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                /*ViewBag.Genres = getGenres.Execute(new GenreQuery()).Data;
                ViewBag.Actors = getActors.Execute(new ActorQuery()).Data;
                ViewBag.Languages = getLanguages.Execute(new LanguageQuery()).Data;
                ViewBag.Writers = getWriters.Execute(new WriterQuery()).Data;*/
                return View(getMovie.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Genres = getGenres.Execute(new GenreQuery()).Data;
                ViewBag.Actors = getActors.Execute(new ActorQuery()).Data;
                ViewBag.Languages = getLanguages.Execute(new LanguageQuery()).Data;
                ViewBag.Writers = getWriters.Execute(new WriterQuery()).Data;
                ViewBag.Countries = getCountries.Execute(new CountryQuery()).Data;
                ViewBag.Productions = getProductions.Execute(new ProductionQuery()).Data;
                ViewBag.Rateds = getRateds.Execute(new RatedQuery()).Data;
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Create));
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addMovie.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Genres = getGenres.Execute(new GenreQuery()).Data;
                ViewBag.Actors = getActors.Execute(new ActorQuery()).Data;
                ViewBag.Languages = getLanguages.Execute(new LanguageQuery()).Data;
                ViewBag.Writers = getWriters.Execute(new WriterQuery()).Data;
                ViewBag.Countries = getCountries.Execute(new CountryQuery()).Data;
                ViewBag.Productions = getProductions.Execute(new ProductionQuery()).Data;
                ViewBag.Rateds = getRateds.Execute(new RatedQuery()).Data;
                return View(getMovie.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieDto dto)
        {
            try
            {
                dto.Id = id;
                editMovie.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getMovie.Execute(id));
            }
            catch (EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteMovie.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}