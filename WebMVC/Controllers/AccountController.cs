﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.ICommands;
using Application.ICommands.HallCommands;
using Application.ICommands.ProjectionCommands;
using Application.ICommands.ReservationCommands;
using Application.ICommands.SeatCommands;
using Application.ICommands.UserCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Session;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginUserCommand loginUser;
        private readonly IGetProjectionsCommand getProjections;
        private readonly IGetProjectionCommand getProjection;
        private readonly IGetReservationsCommand getReservations;
        private readonly IGetHallsCommand getHalls;
        private readonly IGetSeatsCommand getSeats;
        private readonly IGetUserCommand getUser;

        public AccountController(ILoginUserCommand loginUser, IGetProjectionsCommand getProjections, IGetReservationsCommand getReservations, IGetProjectionCommand getProjection, IGetHallsCommand getHalls, IGetSeatsCommand getSeats, IGetUserCommand getUser)
        {
            this.loginUser = loginUser;
            this.getProjections = getProjections;
            this.getReservations = getReservations;
            this.getProjection = getProjection;
            this.getHalls = getHalls;
            this.getSeats = getSeats;
            this.getUser = getUser;
        }

        public IActionResult Index()
        {
            try
            {
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        [HttpPost]
        public IActionResult Login(LoginUserDto user)
        {
            try
             {
                var result = loginUser.Execute(user);
                if (result != null)
                {
                    HttpContext.Session.Set("User", result);
                    ViewBag.User = HttpContext.Session.Get<ShowUserDto>("User");
                    TempData["success"] = "Successfully logged in.";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Email and/or password incorrect; " + e.Message;
            }
            return View("Index");
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Remove("User");
                TempData["success"] = "Successfully logged out.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Index");
        }

        public IActionResult MyProfile(int id)
        {
            try
            {
                return View(getUser.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ShowSeats(int projection, int hall)
        {
            try
            {
                ViewBag.Projection = getProjection.Execute(projection);
                ViewBag.Halls = getHalls.Execute(new HallQuery { Id = hall }).Data;
                ViewBag.Seats = getSeats.Execute(new SeatQuery { HallId = hall, PerPage = 1000 }).Data;
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MyReservations(int id)
        {
            try
            {
                if(HttpContext.Session.Get<ShowUserDto>("User") == null)
                { 
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.User = HttpContext.Session.Get<ShowUserDto>("User");
                    ViewBag.Reservations = getReservations.Execute(new ReservationQuery { PerPage = 100, UserId = id }).Data;
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}