using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.GenreCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGetGenresCommand getGenres;
        private readonly IGetGenreCommand getGenre;
        private readonly IAddGenreCommand addGenre;
        private readonly IEditGenreCommand editGenre;
        private readonly IDeleteGenreCommand deleteGenre;

        public GenresController(IGetGenresCommand getGenres, IGetGenreCommand getGenre, IAddGenreCommand addGenre, IEditGenreCommand editGenre, IDeleteGenreCommand deleteGenre)
        {
            this.getGenres = getGenres;
            this.getGenre = getGenre;
            this.addGenre = addGenre;
            this.editGenre = editGenre;
            this.deleteGenre = deleteGenre;
        }

        // GET: Genres
        public ActionResult Index([FromQuery] GenreQuery query)
        {
            try
            {
                return View(getGenres.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getGenre.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Genres/Create
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

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addGenre.Execute(dto);
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

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(getGenre.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Genres/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GenreDto dto)
        {
            try
            {
                dto.Id = id;
                editGenre.Execute(dto);
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

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getGenre.Execute(id));
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

        // POST: Genres/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteGenre.Execute(id);
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