﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.MovieCommands;
using Application.ICommands.PosterCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class PostersController : Controller
    {
        private readonly UseCaseExecutor executor;
        private readonly IGetPostersCommand getPosters;
        private readonly IGetPosterCommand getPoster;
        private readonly IAddPosterCommand addPoster;
        private readonly IEditPosterCommand editPoster;
        private readonly IDeletePosterCommand deletePoster;
        private readonly IGetMoviesCommand getMovies;

        public PostersController(IGetPostersCommand getPosters, IGetPosterCommand getPoster, IAddPosterCommand addPoster, IEditPosterCommand editPoster, IDeletePosterCommand deletePoster, IGetMoviesCommand getMovies, UseCaseExecutor executor)
        {
            this.getPosters = getPosters;
            this.getPoster = getPoster;
            this.addPoster = addPoster;
            this.editPoster = editPoster;
            this.deletePoster = deletePoster;
            this.getMovies = getMovies;
            this.executor = executor;
        }

        // GET: Posters
        public ActionResult Index([FromQuery] PosterQuery query)
        {
            try
            {
                return View(getPosters.Execute(query));
            }
            catch (EntityNotAllowedException)
            {
                return RedirectToAction("PageNotFound", "Redirections");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Posters/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getPoster.Execute(id));
            }
            catch (EntityNotAllowedException)
            {
                return RedirectToAction("PageNotFound", "Redirections");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Posters/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Movies = getMovies.Execute(new MovieQuery()).Data;
                return View();
            }
            catch (EntityNotAllowedException)
            {
                return RedirectToAction("PageNotFound", "Redirections");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Create));
        }

        // POST: Posters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]PosterDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Something went wrong, check input and try again.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addPoster.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotAllowedException)
            {
                return RedirectToAction("PageNotFound", "Redirections");
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

        // GET: Posters/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(getPoster.Execute(id));
            }
            catch (EntityNotAllowedException)
            {
                return RedirectToAction("PageNotFound", "Redirections");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Posters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[FromBody] PosterDto dto)
        {
            try
            {
                dto.Id = id;
                editPoster.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotAllowedException)
            {
                return RedirectToAction("PageNotFound", "Redirections");
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

        // GET: Posters/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getPoster.Execute(id));
            }
            catch (EntityNotAllowedException)
            {
                return RedirectToAction("PageNotFound", "Redirections");
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

        // POST: Posters/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deletePoster.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotAllowedException)
            {
                return RedirectToAction("PageNotFound", "Redirections");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}