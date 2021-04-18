using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands;
using Application.ICommands.HallCommands;
using Application.ICommands.ProjectionCommands;
using Application.ICommands.ReservationCommands;
using Application.ICommands.RoleCommands;
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
        private readonly IGetRolesCommand getRoles;
        private readonly IAddReservationCommand addReservation;
        private readonly IGetHallsCommand getHalls;
        private readonly IGetSeatsCommand getSeats;
        private readonly IGetUserCommand getUser;
        private readonly ITakenSeatsCommand takenSeats;
        private readonly IAddUserCommand addUser;
        private readonly IUpdateUserProfileCommand updateUser;
        private readonly IUpdateUserPasswordCommand updateUserPassword;

        public AccountController(ILoginUserCommand loginUser, IGetProjectionsCommand getProjections, IGetReservationsCommand getReservations, IGetProjectionCommand getProjection, IGetHallsCommand getHalls, IGetSeatsCommand getSeats, IGetUserCommand getUser, IAddReservationCommand addReservation, ITakenSeatsCommand takenSeats, IAddUserCommand addUser, IUpdateUserProfileCommand updateUser, IGetRolesCommand getRoles, IUpdateUserPasswordCommand updateUserPassword)
        {
            this.loginUser = loginUser;
            this.getProjections = getProjections;
            this.getReservations = getReservations;
            this.getProjection = getProjection;
            this.getHalls = getHalls;
            this.getSeats = getSeats;
            this.getUser = getUser;
            this.addReservation = addReservation;
            this.takenSeats = takenSeats;
            this.addUser = addUser;
            this.updateUser = updateUser;
            this.getRoles = getRoles;
            this.updateUserPassword = updateUserPassword;
        }

        public IActionResult Index()
        {
            try
            {
                if(HttpContext.Session.Get<ShowUserDto>("User") != null)
                {
                    TempData["error"] = "You are already logged in.";
                    return RedirectToAction("Index", "Home");
                }
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
                else
                {
                    TempData["error"] = "Oopps...Somethng went wrong, please try again.";
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
                if (HttpContext.Session.Get<ShowUserDto>("User") != null)
                {
                    HttpContext.Session.Remove("User");
                    TempData["success"] = "Successfully logged out.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "You are not logged in.";
                    return RedirectToAction("Index", "Home");
                }
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
                if(HttpContext.Session.Get<ShowUserDto>("User") == null)
                {
                    TempData["error"] = "You must log in order to browse your profile.";
                    return RedirectToAction("Index");
                }
                ViewBag.Roles = getRoles.Execute(new RoleQuery { PerPage = 100 }).Data;
                ViewBag.Reservations = getReservations.Execute(new ReservationQuery { UserId = id, EndTime = DateTime.Now, PerPage = 50 }).Data;
                return View(getUser.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateProfile(UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction("MyProfile", new { dto.Id });
            }
            try
            {
                updateUser.Execute(dto);
                TempData["success"] = "You successfully updated your profile.";
            }
            catch(EntityCannotBeNullException e)
            {
                TempData["error"] = e.Message;
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            catch (EntityMustHaveConfirmedPassword e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("MyProfile", "Account", new { dto.Id });
        }

        [HttpGet]
        public IActionResult ShowUpdatePassword(int id)
        {
            try
            {
                if (HttpContext.Session.Get<ShowUserDto>("User") == null)
                {
                    TempData["error"] = "You must log in order to browse your profile.";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdatePassword(UpdatePasswordDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction("MyProfile", new { dto.Id });
            }
            try
            {
                updateUserPassword.Execute(dto);
                TempData["success"] = "You successfully updated your profile.";
            }
            catch (EntityCannotBeNullException e)
            {
                TempData["error"] = e.Message;
            }
            catch (EntityMustHaveConfirmedPassword e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("MyProfile", "Account", new { dto.Id });
        }

        public IActionResult ShowSeats(int projection, int hall)
        {
            try
            {
                ViewBag.Taken = takenSeats.Execute(projection);
                ViewBag.Projection = getProjection.Execute(projection);
                ViewBag.Halls = getHalls.Execute(new HallQuery { Id = hall }).Data;
                ViewBag.Rows = getSeats.Execute(new SeatQuery { HallId = hall, PerPage = 1000 }).Data;
                ViewBag.Taken = takenSeats.Execute(projection);
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult MakeReservation(ReservationDto dto, int userid)
        {
            try
            {
                addReservation.Execute(dto);
                TempData["success"] = "Success! Your reservation has been confirmed.";
                return RedirectToAction("MyProfile", new { id = userid });
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Index", "Home"); 
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

        [HttpGet]
        [Route("{action}")]
        public IActionResult SignUpPage()
        {
            try
            {
                if (HttpContext.Session.Get<ShowUserDto>("User") != null)
                {
                    TempData["error"] = "You are already logged in.";
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult SignUp(AddUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(SignUpPage));
            }
            try
            {
                var u = HttpContext.Session.Get<ShowUserDto>("User");
                if(u != null)
                {
                    if (u.RoleId != 2)
                    {
                        dto.RoleId = 1;
                    }
                    else
                    {
                        dto.RoleId = 2;
                    }
                }
                else
                {
                    dto.RoleId = 2;
                }

                addUser.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction(nameof(SignUpPage));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction(nameof(SignUpPage));
            }
        }
    }
}