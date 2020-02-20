using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IGetHallsCommand getHalls;
        private readonly IGetHallCommand getHall;
        private readonly IAddHallCommand addHall;
        private readonly IEditHallCommand editHall;
        private readonly IDeleteHallCommand deleteHall;

        public HallsController(IGetHallsCommand getHalls, IGetHallCommand getHall, IAddHallCommand addHall, IEditHallCommand editHall, IDeleteHallCommand deleteHall)
        {
            this.getHalls = getHalls;
            this.getHall = getHall;
            this.addHall = addHall;
            this.editHall = editHall;
            this.deleteHall = deleteHall;
        }

        // GET: Halls
        public ActionResult Index([FromQuery] HallQuery query)
        {
            try
            {
                return View(getHalls.Execute(query));
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
                return View(getHall.Execute(id));
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
                addHall.Execute(dto);
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

        // GET: Halls/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(getHall.Execute(id));
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
                editHall.Execute(dto);
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

        // GET: Halls/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getHall.Execute(id));
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
                deleteHall.Execute(id);
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