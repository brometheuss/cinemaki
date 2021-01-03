using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.ICommands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Session;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginUserCommand loginUser;

        public AccountController(ILoginUserCommand loginUser)
        {
            this.loginUser = loginUser;
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
    }
}