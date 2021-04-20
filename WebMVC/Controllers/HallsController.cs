using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.HallCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class HallsController : Controller
    {
        private readonly UseCaseExecutor executor;
        private readonly IGetHallsCommand getHalls;
        private readonly IGetHallCommand getHall;
        private readonly IAddHallCommand addHall;
        private readonly IEditHallCommand editHall;
        private readonly IDeleteHallCommand deleteHall;

        public HallsController(IGetHallsCommand getHalls, IGetHallCommand getHall, IAddHallCommand addHall, IEditHallCommand editHall, IDeleteHallCommand deleteHall, UseCaseExecutor executor)
        {
            this.getHalls = getHalls;
            this.getHall = getHall;
            this.addHall = addHall;
            this.editHall = editHall;
            this.deleteHall = deleteHall;
            this.executor = executor;
        }

        // GET: Halls
        public ActionResult Index([FromQuery] HallQuery query)
        {
            try
            {
                return View(executor.ExecuteQuery(getHalls, query));
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

        // GET: Halls/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getHall, id));
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

        // GET: Halls/Create
        public ActionResult Create()
        {
            try
            {
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

        // POST: Halls/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HallDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                executor.ExecuteCommand(addHall, dto);
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

        // GET: Halls/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getHall, id));
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

        // POST: Halls/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HallDto dto)
        {
            try
            {
                dto.Id = id;
                executor.ExecuteCommand(editHall, dto);
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

        // GET: Halls/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getHall, id));
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

        // POST: Halls/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                executor.ExecuteCommand(deleteHall, id);
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