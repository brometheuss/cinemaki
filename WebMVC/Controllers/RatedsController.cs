using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RatedCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class RatedsController : Controller
    {
        private readonly IGetRatedsCommand getRateds;
        private readonly IGetRatedCommand getRated;
        private readonly IAddRatedCommand addRated;
        private readonly IEditRatedCommand editRated;
        private readonly IDeleteRatedCommand deleteRated;

        public RatedsController(IGetRatedsCommand getRateds, IGetRatedCommand getRated, IAddRatedCommand addRated, IEditRatedCommand editRated, IDeleteRatedCommand deleteRated)
        {
            this.getRateds = getRateds;
            this.getRated = getRated;
            this.addRated = addRated;
            this.editRated = editRated;
            this.deleteRated = deleteRated;
        }

        // GET: Rateds
        public ActionResult Index([FromQuery] RatedQuery query)
        {
            try
            {
                return View(getRateds.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Rateds/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getRated.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Rateds/Create
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

        // POST: Rateds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatedDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addRated.Execute(dto);
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

        // GET: Rateds/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(getRated.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Rateds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatedDto dto)
        {
            try
            {
                dto.Id = id;
                editRated.Execute(dto);
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

        // GET: Rateds/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getRated.Execute(id));
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

        // POST: Rateds/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteRated.Execute(id);
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