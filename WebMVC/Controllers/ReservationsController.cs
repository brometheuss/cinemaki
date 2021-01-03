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
using Application.ICommands.ReservationCommands;
using Application.ICommands.UserCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IAddReservationCommand addReservation;
        private readonly IGetReservationCommand getReservation;
        private readonly IGetReservationsCommand getReservations;
        private readonly IDeleteReservationCommand deleteReservation;
        private readonly IGetHallsCommand getHalls;
        private readonly IGetMoviesCommand getMovies;
        private readonly IGetUsersCommand getUsers;
        private readonly IGetProjectionsCommand getProjections;
        private readonly UseCaseExecutor executor;

        public ReservationsController(IAddReservationCommand addReservation, IGetReservationCommand getReservation, IGetReservationsCommand getReservations, IGetHallsCommand getHalls, IGetMoviesCommand getMovies, IGetUsersCommand getUsers, IGetProjectionsCommand getProjections, UseCaseExecutor executor, IDeleteReservationCommand deleteReservation)
        {
            this.addReservation = addReservation;
            this.getReservation = getReservation;
            this.getReservations = getReservations;
            this.getHalls = getHalls;
            this.getMovies = getMovies;
            this.getUsers = getUsers;
            this.getProjections = getProjections;
            this.executor = executor;
            this.deleteReservation = deleteReservation;
        }

        // GET: Reservations
        public ActionResult Index([FromQuery]ReservationQuery query)
        {
            try
            {
                return View(getReservations.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getReservation.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Halls = getHalls.Execute(new HallQuery()).Data;
                ViewBag.Movies = getMovies.Execute(new MovieQuery()).Data;
                ViewBag.Users = getUsers.Execute(new UserQuery()).Data;
                ViewBag.Projections = getProjections.Execute(new ProjectionQuery()).Data;
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Create));
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationDto dto, IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                executor.ExecuteCommand(addReservation, dto);
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

        // GET: Reservations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getReservation, id));
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

        // POST: Reservations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                executor.ExecuteCommand(deleteReservation, id);
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