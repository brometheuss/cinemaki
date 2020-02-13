using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ICommands.WriterCommands;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Writers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Writers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Writers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Writers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Writers/Edit/5
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

        // GET: Writers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Writers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}