using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.HallCommands;
using Application.ICommands.MovieCommands;
using Application.ICommands.ProjectionCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class ProjectionsController : Controller
    {
        private readonly UseCaseExecutor executor;
        private readonly IGetProjectionsCommand getProjections;
        private readonly IGetProjectionCommand getProjection;
        private readonly IAddProjectionCommand addProjection;
        private readonly IEditProjectionCommand editProjection;
        private readonly IDeleteProjectionCommand deleteProjection;
        private readonly IGetMoviesCommand getMovies;
        private readonly IGetHallsCommand getHalls;

        public ProjectionsController(IGetProjectionsCommand getProjections, IGetProjectionCommand getProjection, IAddProjectionCommand addProjection, IEditProjectionCommand editProjection, IDeleteProjectionCommand deleteProjection, IGetMoviesCommand getMovies, IGetHallsCommand getHalls, UseCaseExecutor executor)
        {
            this.getProjections = getProjections;
            this.getProjection = getProjection;
            this.addProjection = addProjection;
            this.editProjection = editProjection;
            this.deleteProjection = deleteProjection;
            this.getMovies = getMovies;
            this.getHalls = getHalls;
            this.executor = executor;
        }

        // GET: Projections
        public ActionResult Index([FromQuery] ProjectionQuery query)
        {
            try
            {
                return View(executor.ExecuteQuery(getProjections, query));
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

        // GET: Projections/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getProjection, id));
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

        // GET: Projections/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Halls = getHalls.Execute(new HallQuery()).Data;
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

        // POST: Projections/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectionDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                executor.ExecuteCommand(addProjection, dto);
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

        // GET: Projections/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Halls = getHalls.Execute(new HallQuery { PerPage = 100 }).Data;
                ViewBag.Movies = getMovies.Execute(new MovieQuery { PerPage = 1000 }).Data;
                return View(executor.ExecuteQuery(getProjection, id));
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

        // POST: Projections/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectionDto dto)
        {
            try
            {
                dto.Id = id;
                executor.ExecuteCommand(editProjection, dto);
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

        // GET: Projections/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getProjection, id));
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

        // POST: Projections/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                executor.ExecuteCommand(deleteProjection, id);
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