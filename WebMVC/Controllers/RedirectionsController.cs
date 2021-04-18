using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class RedirectionsController : Controller
    {
        [HttpGet]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}