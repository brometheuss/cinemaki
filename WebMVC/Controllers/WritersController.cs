using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.WriterCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class WritersController : Controller
    {
        private readonly IGetWritersCommand getWriters;
        private readonly IGetWriterCommand getWriter;
        private readonly IAddWriterCommand addWriter;
        private readonly IEditWriterCommand editWriter;
        private readonly IDeleteWriterCommand deleteWriter;

        public WritersController(IGetWritersCommand getWriters, IGetWriterCommand getWriter, IAddWriterCommand addWriter, IEditWriterCommand editWriter, IDeleteWriterCommand deleteWriter)
        {
            this.getWriters = getWriters;
            this.getWriter = getWriter;
            this.addWriter = addWriter;
            this.editWriter = editWriter;
            this.deleteWriter = deleteWriter;
        }

        // GET: Writers
        public ActionResult Index([FromQuery] WriterQuery query)
        {
            try
            {
                return View(getWriters.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Writers/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getWriter.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Writers/Create
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

        // POST: Writers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WriterDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addWriter.Execute(dto);
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

        // GET: Writers/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(getWriter.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Writers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WriterDto dto)
        {
            try
            {
                dto.Id = id;
                editWriter.Execute(dto);
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

        // GET: Writers/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getWriter.Execute(id));
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

        // POST: Writers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteWriter.Execute(id);
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