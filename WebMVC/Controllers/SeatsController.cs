﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.SeatCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class SeatsController : Controller
    {
        private readonly IGetSeatsCommand getSeats;
        private readonly IGetSeatCommand getSeat;
        private readonly IAddSeatCommand addSeat;
        private readonly IEditSeatCommand editSeat;
        private readonly IDeleteSeatCommand deleteSeat;

        public SeatsController(IGetSeatsCommand getSeats, IGetSeatCommand getSeat, IAddSeatCommand addSeat, IEditSeatCommand editSeat, IDeleteSeatCommand deleteSeat)
        {
            this.getSeats = getSeats;
            this.getSeat = getSeat;
            this.addSeat = addSeat;
            this.editSeat = editSeat;
            this.deleteSeat = deleteSeat;
        }

        // GET: Seats
        public ActionResult Index([FromQuery] SeatQuery query)
        {
            try
            {
                return View(getSeats.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Seats/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getSeat.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Seats/Create
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

        // POST: Seats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeatDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addSeat.Execute(dto);
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

        // GET: Seats/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(getSeat.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Seats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SeatDto dto)
        {
            try
            {
                dto.Id = id;
                editSeat.Execute(dto);
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

        // GET: Seats/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getSeat.Execute(id));
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

        // POST: Seats/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteSeat.Execute(id);
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